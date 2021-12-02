using UnityEngine;

public class RemoveObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    public float speed;

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {

            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
            obstacle.SetActive(true);
        }

        if (Vector3.Distance(transform.position, other.transform.position) <= 0.5) Destroy(gameObject);
    }
}
