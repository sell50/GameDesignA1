using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGrenade : MonoBehaviour
{
    public int abilityCooldown;
    public bool isActive;
    public GameObject projectile;
    public float launchVelocity = 700f;
    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown = 0;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")) //key for ability activate
        {
            isActive = true;
            abilityCooldown = 10;
            GameObject grenade = Instantiate(projectile, transform.position,  
                                                     transform.rotation);
            grenade.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 
                                                (0, launchVelocity,0));
            StartCoroutine(Cooldown());
        }

    }

     IEnumerator Cooldown()
    {
        while(abilityCooldown>0)
        {
            abilityCooldown--;
            yield return new WaitForSeconds(1);
        }
    }

}
