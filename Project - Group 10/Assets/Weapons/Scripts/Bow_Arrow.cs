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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Aim", true);
            currentPos = Instantiate(arrow, drawFrom.position, Quaternion.identity, transform);
            Draw_Arrow(15);
            Shoot(15);
        }
        else if (Input.GetMouseButtonUp(0)) anim.SetBool("Aim", false);
    }

    void Shoot(float shotForce)
    {
        draw = false;
        currentPos.transform.parent = null;
        Rigidbody projectileRigidBody = currentPos.GetComponent<Rigidbody>();
        projectileRigidBody.isKinematic = false;
        projectileRigidBody.AddForce(transform.right * shotForce, ForceMode.Impulse);
        
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
            //reduce character health 6-9 damage
        }
    }
}
