using System;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

namespace Characters.Scripts
{
    public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        private PlayerSpawner _playerSpawner;
        private bool isFiring;

        #region Public Fields

        [Tooltip("The current health of our player.")]
        public float health = 100f;

        //public PhotonView photonView;
        public static GameObject LocalPlayerInstance;
        
        #endregion

        #region IPunObservable implementation

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(isFiring);
                stream.SendNext(health);
            }
            else
            {
                isFiring = (bool) stream.ReceiveNext();
                health = (float) stream.ReceiveNext();
            }
        }

        public override void OnDisable()
        {
            base.OnDisable();
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        #endregion

        #region Private Methods

        void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene,
            UnityEngine.SceneManagement.LoadSceneMode loadingMode)
        {
            CalledOnLevelWasLoaded(scene.buildIndex);
        }
        

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //don't do anything if you're not the local player
            if (!photonView.IsMine)
            {
            }
        }

        private void Awake()
        {
            //photonView = gameObject.GetPhotonView();
            
            if (photonView.IsMine)
            {
                LocalPlayerInstance = gameObject;
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (photonView.IsMine)
            {
                if (Camera.main is { }) Camera.main.GetComponent<CameraFollow>().SetTarget(gameObject.transform);
                _playerSpawner = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
            }

            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void TakeDamage(int damage)
        {
            if (photonView.IsMine)
            {
                health -= damage;
                if (health <= 0)
                {
                    _playerSpawner.Respawn();
                    PhotonNetwork.Destroy(gameObject);
                }
            }
        }

        void CalledOnLevelWasLoaded(int level)
        {
            if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
            {
                transform.position = new Vector3(0f, 5f, 0f);
            }
        }
    }
}
