using Runtime.Data.ValueObjects.PlayerData;
using Runtime.Keys;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        [ShowInInspector] private PlayerMovementData _data;
        [ShowInInspector] private bool _isReadyToMove, _isReadToPlay;
        [ShowInInspector] private float _xValue;
        private float2 _clampValues;


        public void SetData(PlayerMovementData data)
        {
            _data = data;
        }

        private void FixedUpdate()
        {
            if (!_isReadToPlay)
            {
                StopPlayer();
                return;
            }

            if (_isReadyToMove)
            {
                MovePlayer();
            }
            else
            {
                StopPlayerHorizontally();
            }
        }

        void StopPlayer()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        void StopPlayerHorizontally()
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _data.ForwardSpeed);
            _rigidbody.angularVelocity = Vector3.zero;
        }

        private void MovePlayer()
        {
            var velocity = _rigidbody.velocity;
            velocity = new Vector3(_xValue * _data.SidewaySpeed, velocity.y, _data.ForwardSpeed);
            _rigidbody.velocity = velocity;
            Vector3 position1 = _rigidbody.position;
            Vector3 position;
            position = new Vector3(Mathf.Clamp(position1.x, _clampValues.x, _clampValues.y),
                (position = _rigidbody.position).y, position.z);
            _rigidbody.position = position;
        }

        internal void IsReadyToPlay(bool condition)
        {
            _isReadToPlay = condition;
        }

        internal void IsReadyToMove(bool condition)
        {
            _isReadyToMove = condition;
        }

        internal void UpdateInputParams(HorizontalInputParams inputParams)
        {
            _xValue = inputParams.HozirontalValue;
            _clampValues = inputParams.ClampValues;
        }

        internal void OnReset()
        {
            StopPlayer();
            _isReadyToMove = false;
            _isReadToPlay = false;
        }
        

    }
}