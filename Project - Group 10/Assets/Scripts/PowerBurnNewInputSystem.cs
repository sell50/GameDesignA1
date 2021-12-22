using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class PowerBurnNewInputSystem : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PhotonView _photonView;
    
    int abilityCooldown;
    bool isActive;
    bool isDamaged;
    int timer;
    int health;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _photonView = GetComponent<PhotonView>();

        _playerInput.PowerControls.ActivatePower.performed += OnPowerActivate;
    }
    
    void OnPowerActivate(InputAction.CallbackContext ctx)
    {
        isActive = ctx.ReadValueAsButton();
    }

    void Power()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown = 0;
        isActive = false;
        isDamaged = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")) //key for ability activate
        {
            isActive = true;
            abilityCooldown = 12;
            health-=7;     
            isDamaged = true;    
        }

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        while(timer<=3)
        {
            timer++;
            health-=7;
            yield return new WaitForSeconds(1);
        }
        while(abilityCooldown>=0)
        {
            abilityCooldown--;
            yield return new WaitForSeconds(1);
        }
    }
}
