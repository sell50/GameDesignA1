using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerCharacter;
    public Vector3 offset;

    void Start()
    {
        //offset = transform.position - playerCharacter.transform.position;
        offset = new Vector3(0, 10, -10);
    }

    void LateUpdate()
    {
        transform.position = playerCharacter.transform.position + offset;
        transform.LookAt(playerCharacter);
    }
}
