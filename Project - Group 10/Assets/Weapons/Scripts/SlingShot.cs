using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShot : MonoBehaviour
{
    public Transform projectile;
    public Transform drawFrom;
    public Transform drawTo;
    public int increments = 10;

    public SlingShotString slingString;

    private Transform currentPos;
    private bool draw;

    public ItemPickup count;
    public int ammoCount;

    void Start()
    {
        count = new ItemPickup();
        ammoCount = count.GetAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if ( ammoCount != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentPos = Instantiate(projectile, drawFrom.position, Quaternion.identity, transform);
                DrawProjectile(0.05f);
            }
            else if (Input.GetMouseButtonUp(0)) ReleaseAndShoot(50);
 
        }
    }
    public void ReleaseAndShoot(float shotForce)
    {
        draw = false;
        currentPos.transform.parent = null;
        Rigidbody projectileRigidBody = currentPos.GetComponent<Rigidbody>();
        projectileRigidBody.isKinematic = false;
        projectileRigidBody.AddForce(transform.forward * shotForce, ForceMode.Impulse);
        slingString.centre = drawFrom;
        ammoCount--;
    }
    public void DrawProjectile(float speed)
    {
        draw = true;
        
        currentPos.forward = transform.forward;
        slingString.centre = currentPos.transform;

        float waitTimeBetweenDraws = speed / increments;
        StartCoroutine(drawSlingShotWithIncrements(waitTimeBetweenDraws));
    }

    private IEnumerator drawSlingShotWithIncrements(float waitTimeBetweenDraws)
    {
        for (int i = 0; i < increments; i++)
        {
            if (draw)
            {
                currentPos.transform.position = Vector3.Lerp(drawFrom.position, drawTo.position, (float)i / increments);
                yield return new WaitForSeconds(waitTimeBetweenDraws);
            }
            else
            {
                i = increments;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")        //choose appropriately
        {
            //reduce character health 1-2 damage    //Use collider in stone i.e currentPos
        }
    }
}
