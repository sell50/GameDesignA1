using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerCharacter;
    public Vector3 offset;

    void Start()
    {
        //offset = transform.position - playerCharacter.transform.position;
        offset = new Vector3(0, 35, 0);
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(playerCharacter.transform.position, (playerCharacter.transform.position + offset), 0.5f);
        transform.LookAt(playerCharacter);
    }
}
