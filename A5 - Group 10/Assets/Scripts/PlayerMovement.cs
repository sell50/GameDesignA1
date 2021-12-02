using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    Camera mainCamera;
    Animator anim;
    Vector3 pos;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isRunning", true);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                pos = hit.point;
                navMeshAgent.SetDestination(hit.point);
                

            }
        }
        if (Vector3.Distance(navMeshAgent.transform.position, pos) <= 3.0f) anim.SetBool("isRunning", false);

    }

}
