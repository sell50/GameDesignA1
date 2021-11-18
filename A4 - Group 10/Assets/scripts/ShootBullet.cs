using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

    [SerializeField] GameObject bullet_prefab;
    [SerializeField] Transform target;
    [SerializeField] float bullet_speed = 50f;
    [SerializeField] float bullet_reload = 0.5f;
    [SerializeField] float rotation_speed = 1f;

    Coroutine firing_coroutine;
    bool can_shoot = true;
    bool is_shooting = false;

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (can_shoot && !is_shooting)
        {
            is_shooting = true;
            firing_coroutine = StartCoroutine(FireContinuously());
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bullet_prefab, transform.position, transform.rotation) as GameObject;
            //Vector3 direction = (target.transform.position - transform.position).normalized;
            //bullet.GetComponent<Rigidbody>().MovePosition(transform.position + direction * bullet_speed * Time.deltaTime);

            //bullet.velocity = transform.TransformDirection(Vector3(0, 0, bullet_speed));
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(Vector3.forward * bullet_speed);
            yield return new WaitForSeconds(bullet_reload);
        }
    }
}