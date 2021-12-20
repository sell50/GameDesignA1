using System;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Scripts
{
    public class AnimationAndMovementController : MonoBehaviourPun
    {
        private PlayerInput _playerInput;
        private CharacterController _characterController;
        private Animator _animator;
        private PhotonView _photonView;

        private Vector2 _movementInput;
        private Vector3 _currentMovement;
        private Vector3 _currentRunMovement;
        private Vector3 _appliedMovement;

        private bool _isMovementPressed;
        private bool _isRunPressed;
        private bool _isJumpPressed;

        private int _isWalkingHash;
        private int _isRunningHash;
        private int _isJumpingHash;
        private bool _isJumping;
        private bool _isJumpAnimating; 

        [SerializeField] private float maxJumpHeight = 4.0f;
        private float _initialJumpVelocity;
        [SerializeField] private float maxJumpTime = 0.75f;

        private float _gravity = -9.81f;
        private float groundedGravity = -0.05f;

        private float runSpeed = 5.0f;
        private float rotationFactorPerFrame = 2.0f;
        private static readonly int IsJumping = Animator.StringToHash("isJumping");

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _photonView = GetComponent<PhotonView>();

            _isWalkingHash = Animator.StringToHash("isWalking");
            _isRunningHash = Animator.StringToHash("isRunning");
            _isJumpingHash = Animator.StringToHash("isJumping");

            _playerInput.CharacterControls.Move.started += OnMovementInput;
            _playerInput.CharacterControls.Move.canceled += OnMovementInput;
            _playerInput.CharacterControls.Move.performed += OnMovementInput;

            _playerInput.CharacterControls.Run.started += OnRun;
            _playerInput.CharacterControls.Run.canceled += OnRun;
            _playerInput.CharacterControls.Run.performed += OnRun;

            _playerInput.CharacterControls.Jump.started += OnJump;
            _playerInput.CharacterControls.Jump.canceled += OnJump;
            _playerInput.CharacterControls.Jump.performed += OnJump;
            
            SetUpJumpVariables();
        }

        void SetUpJumpVariables()
        {
            var timeToApex = maxJumpTime / 2;
            _gravity = -2 * maxJumpHeight / Mathf.Pow(timeToApex, 2);
            _initialJumpVelocity = 2 * maxJumpHeight / timeToApex;
        }

        private void OnMovementInput(InputAction.CallbackContext ctx)
        {
            _movementInput = ctx.ReadValue<Vector2>();
            _currentMovement.x = _movementInput.x;
            _currentMovement.z = _movementInput.y;
            _currentRunMovement.x = _movementInput.x * runSpeed;
            _currentRunMovement.z = _movementInput.y * runSpeed;

            _isMovementPressed = _movementInput.x != 0 || _movementInput.y != 0;
        }

        private void OnRun(InputAction.CallbackContext ctx)
        {
            _isRunPressed = ctx.ReadValueAsButton();
        }
        
        private void OnJump(InputAction.CallbackContext ctx)
        {
            _isJumpPressed = ctx.ReadValueAsButton();
        }

        private void HandleAnimation()
        {
            var isWalking = _animator.GetBool(_isWalkingHash);
            var isRunning = _animator.GetBool(_isRunningHash);

            if (_isMovementPressed && !isWalking)
            {
                _animator.SetBool(_isWalkingHash, true);
            }

            if (!_isMovementPressed && isWalking)
            {
                _animator.SetBool(_isWalkingHash, false);
            }

            if (_isMovementPressed && _isRunPressed && !isRunning)
            {
                _animator.SetBool(_isRunningHash, true);
            } 
            else if ((!_isMovementPressed || !_isRunPressed) && isRunning)
            {
                _animator.SetBool(_isRunningHash, false);
            }
        }

        private void HandleRotation()
        {
            Vector3 positionToLookAt;
            positionToLookAt.x = _currentMovement.x;
            positionToLookAt.y = 0.0f;
            positionToLookAt.z = _currentMovement.z;
            var currentRotation = transform.rotation;

            if (_isMovementPressed)
            {
                var targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
            }
        }

        private void HandleJump()
        {
            if (!_isJumping && _characterController.isGrounded && _isJumpPressed)
            {
                _isJumping = true;
                _animator.SetBool(_isJumpingHash, true);
                _isJumpAnimating = true;
                _currentMovement.y = _initialJumpVelocity;
                _appliedMovement.y = _initialJumpVelocity;
            }
            else if (!_isJumpPressed && _isJumping && _characterController.isGrounded)
            {
                _isJumping = false;
            }
        }

        private void HandleGravity()
        {
            var isFalling = _currentMovement.y <= 0.0f || !_isJumpPressed;
            var fallMultiplier = 2f;

            if (_characterController.isGrounded)
            {
                if (_isJumpAnimating)
                {
                    _animator.SetBool(_isJumpingHash, false);
                }
                _currentMovement.y = groundedGravity;
                _currentRunMovement.y = groundedGravity;
            }
            else if (isFalling)
            {
                var prevYVelocity = _currentMovement.y;
                _currentMovement.y = _currentMovement.y + _gravity * fallMultiplier * Time.deltaTime;
                _appliedMovement.y = Mathf.Max((prevYVelocity + _currentMovement.y) * 0.5f, - 20.0f);
            }
            else
            {
                var prevYVelocity = _currentMovement.y;
                _currentMovement.y = _currentMovement.y + _gravity * fallMultiplier * Time.deltaTime;
                _appliedMovement.y = (prevYVelocity + _currentMovement.y) * 0.5f;
            }
        }
        
        private void Start()
        {
            var cameraWork = this.gameObject.GetComponent<CameraWork>();


            if (cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    cameraWork.OnStartFollowing();
                }
            }
            else
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
            }
        }

        private void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected)
            {
                return;
            }

            HandleAnimation();
            HandleRotation();
            
            if (_isRunPressed)
            {
                _appliedMovement.x = _currentRunMovement.x;
                _appliedMovement.z = _currentRunMovement.z;
            }
            else
            {
                _appliedMovement.x = _currentMovement.x;
                _appliedMovement.z = _currentMovement.z;
            }

            _characterController.Move(_appliedMovement * Time.deltaTime);
            
            HandleGravity();
            HandleJump();
        }

        private void OnEnable()
        {
            _playerInput.CharacterControls.Enable();
        }

        private void OnDisable()
        {
            _playerInput.CharacterControls.Disable();
        }
    }
}
