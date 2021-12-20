using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviourPun
{
    [Header("Camera")]
    [SerializeField] private Vector2 maxFollowOffset = new Vector2(-1f, 6f);

    [SerializeField] private Vector2 cameraVelocity = new Vector2(4f, 0.25f);

    [SerializeField] private Transform playerTransform = null;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera = null;

    private CinemachineTransposer _transposer;
    
    void Start()
    {
        if (photonView.IsMine)
        {
            _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            _virtualCamera.gameObject.SetActive(true);
            enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
