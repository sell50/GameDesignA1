
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZoneLoader : MonoBehaviour
{
    private Collider coll;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Loader.Load(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
