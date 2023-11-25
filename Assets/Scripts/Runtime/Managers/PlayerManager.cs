using System;
using Runtime.Commands.Player;
using Runtime.Controllers.Player;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects.PlayerData;
using Runtime.Interfaces;
using Runtime.Keys;
using Runtime.Signals;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour, ISubscribe
    {
        public byte StageValue;
        internal ForceBallsToPoolCommand ForceCommand;

        [SerializeField] private PlayerMovementController _movementController;
        [SerializeField] private PlayerMeshController _meshController;
        [SerializeField] private PlayerPhysicsController _physicsController;
        private PlayerData _data;

        private void Awake()
        {
            _data = GetPlayerData();
            SendDataToController();
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

        private void SendDataToController()
        {
            _movementController.SetData(_data.MovementData);
            _meshController.SetData(_data.MeshData);
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").data;
        }

        private void Init()
        {
            ForceCommand = new ForceBallsToPoolCommand(this, _data.ForceData);
        }

        public void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnInputTaken;
            InputSignals.Instance.onInputReleased += OnInputReleased;
            InputSignals.Instance.onInputDragged += OnInputDragged;
            UISignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onStageAreaEntered += OnStageAreaEntered;
            CoreGameSignals.Instance.onStageAreaSuccessful += OnStageAreaSuccessful;
            CoreGameSignals.Instance.onFinishAreaEntered += OnFinishAreaEntered;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnFinishAreaEntered()
        {
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            //Mini game yazılmalı
        }

        private void OnStageAreaSuccessful(byte value)
        {
            StageValue = (byte)++value;
        }

        private void OnStageAreaEntered()
        {
            _movementController.IsReadyToPlay(false);
        }


        private void OnLevelFailed()
        {
            _movementController.IsReadyToPlay(false);
        }

        private void OnLevelSuccessful()
        {
            _movementController.IsReadyToPlay(false);
        }

        private void OnReset()
        {
            StageValue = 0;
            _movementController.OnReset();
            _physicsController.OnReset();
            _meshController.OnReset();
        }

        private void OnPlay()
        {
            _movementController.IsReadyToPlay(true);
        }

        private void OnInputDragged(HorizontalInputParams inputParams)
        {
            _movementController.UpdateInputParams(inputParams);
        }

        private void OnInputReleased()
        {
            _movementController.IsReadyToMove(false);
        }

        private void OnInputTaken()
        {
            _movementController.IsReadyToMove(true);
        }

        public void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
            InputSignals.Instance.onInputDragged -= OnInputDragged;
            UISignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onStageAreaEntered -= OnStageAreaEntered;
            CoreGameSignals.Instance.onStageAreaSuccessful -= OnStageAreaSuccessful;
            CoreGameSignals.Instance.onFinishAreaEntered -= OnFinishAreaEntered;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}