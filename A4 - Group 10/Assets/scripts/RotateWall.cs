using UnityEngine;

public class RotateWall : MonoBehaviour
{


    void Update()
    {
        transform.Rotate(0, Time.deltaTime * -15f, 0);
        
            
    }
}
