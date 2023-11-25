using System;
using Cinemachine;
using Runtime.Interfaces;
using Runtime.Signals;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Runtime.Managers
{
    public class CameraManager : MonoBehaviour, ISubscribe
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        private float3 _firstPosition;

        private void Start()
        {
            Init();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void Init()
        {
            _firstPosition = _virtualCamera.transform.position;
        }

        public void SubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnReset()
        {
            _virtualCamera.transform.position = _firstPosition;
        }

        private void OnSetCameraTarget()
        {
            // var player = FindObjectOfType<PlayerManager>().transform;
            // _virtualCamera.Follow = player;
            // _virtualCamera.LookAt player;
        }

        public void UnsubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}