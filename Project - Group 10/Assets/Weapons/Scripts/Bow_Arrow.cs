using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Arrow : MonoBehaviour
{

    public Transform arrow;
    public int increments = 10;
    public Transform drawFrom;
    public Transform drawTo;

    private Transform currentPos;
    private bool draw;
    public Animator anim;
    public ItemPickup count;
    public int ammoCount;
    float shotForce = 15;
    void Start()
    {
        count = new ItemPickup();
        ammoCount = count.GetAmmo();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (ammoCount != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Aim", true);
                currentPos = Instantiate(arrow, drawFrom.position, Quaternion.identity, transform);
                Draw_Arrow(15);
                StartCoroutine(Shoot());
            }
            else if (Input.GetMouseButtonUp(0)) anim.SetBool("Aim", false);
        }
    }

    private IEnumerator Shoot()
    {
        draw = false;
        currentPos.transform.parent = null;
        Rigidbody projectileRigidBody = currentPos.GetComponent<Rigidbody>();
        projectileRigidBody.isKinematic = false;
        projectileRigidBody.AddForce(transform.right * shotForce, ForceMode.Impulse);
        ammoCount--;
        yield return new WaitForSeconds(4);

    }
    void Draw_Arrow(float speed)
    {
        draw = true;
        currentPos.forward = transform.forward;
        StartCoroutine(drawBowArrow());
    }

    private IEnumerator drawBowArrow()
    {
        for (int i = 0; i < increments; i++)
        {
            if (draw)
            {
                currentPos.transform.position = Vector3.Lerp(drawFrom.position, drawTo.position, (float)i / increments);
                yield return new WaitForSeconds(1.5f);
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
            //reduce character health 6-9 damage     //Add collider in arrow i.e currentPos
        }
    }
}
