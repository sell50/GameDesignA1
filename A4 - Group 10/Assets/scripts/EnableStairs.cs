using UnityEngine;

public class EnableStairs : MonoBehaviour
{
    [SerializeField] private GameObject stairs;

    
    void Update()
    {
        transform.Rotate(   Time.deltaTime * 30f,
                            Time.deltaTime * 15f,
                            Time.deltaTime * 45f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            stairs.SetActive(true);
            Destroy(gameObject);
        }
    }
}
