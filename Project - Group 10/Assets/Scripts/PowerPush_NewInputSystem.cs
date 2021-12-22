using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class PowerPush_NewInputSystem : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PhotonView _photonView;
    
    int abilityCooldown;
    bool isActive;
    float force = 3;

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

    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown = 0;
        isActive = false;
    }

    
    void Power()
    {
        //ability goes here
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine == false && PhotonNetwork.IsConnected)
        {
            return;
        }
        
        if (isActive)
        {
            Power();
            abilityCooldown = 12;
        }
        
        /*if(Input.GetKeyDown("o")) //key for ability activate
        {
            isActive = true;
            
            
        }*/
        StartCoroutine(Cooldown());
    }

     IEnumerator Cooldown()
    {
        while(abilityCooldown>0)
        {
            abilityCooldown--;
            yield return new WaitForSeconds(1);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        float force = 3;
        if (other.gameObject.tag == "enemy")
        {
            
            Vector3 dir = other.contacts[0].point - transform.position;
            
            dir = -dir.normalized;
    
            GetComponent<Rigidbody>().AddForce(dir*force);
        }
    }
    
    private void OnEnable()
    {
        if (_photonView.IsMine)
        {
            _playerInput.PowerControls.Enable();
        }
    }

    private void OnDisable()
    {
        if (_photonView.IsMine)
        {
            _playerInput.PowerControls.Disable();
        }
    }

}
