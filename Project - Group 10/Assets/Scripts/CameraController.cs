using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class CameraController : MonoBehaviourPun
{
    [Header("Camera")]
    [SerializeField] private Vector2 maxFollowOffset = new Vector2(-1f, 6f);

    [SerializeField] private Vector2 cameraVelocity = new Vector2(4f, 0.25f);

    [SerializeField] private Transform playerTransform = null;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera = null;

    private CinemachineTransposer _transposer;
    private PlayerInput _playerInput;
    private PhotonView _photonView;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (_photonView.IsMine)
        {
            _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            _virtualCamera.gameObject.SetActive(true);
            enabled = true;
            
            _playerInput.Camera.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());
        }
    }

    private void Look(Vector2 lookAxis)
    {
        var deltaTime = Time.deltaTime;
        var followOffset = Mathf.Clamp(
            _transposer.m_FollowOffset.y - (lookAxis.y * cameraVelocity.y * deltaTime),
            maxFollowOffset.x,
            maxFollowOffset.y);
        _transposer.m_FollowOffset.y = followOffset;
        playerTransform.Rotate(0f, lookAxis.x * cameraVelocity.x * deltaTime, 0f);
    }

    private void OnEnable()
    {
        _playerInput.Camera.Enable();
        /*if (_photonView.IsMine)
        {
            _playerInput.Camera.Enable();
        }*/
    }

    private void OnDisable()
    {
        _playerInput.Camera.Disable();
        /*if (_photonView.IsMine)
        {
            _playerInput.Camera.Disable();
        }*/
    }
}
