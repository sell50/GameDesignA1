using UnityEngine;

public class RemoveObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;


    void Update()
    {
        transform.Rotate(Time.deltaTime * 30f,
                            Time.deltaTime * 15f,
                            Time.deltaTime * 45f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (obstacle.activeSelf) 
            {
                obstacle.SetActive(false);
            }
            else 
            {
                obstacle.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}
