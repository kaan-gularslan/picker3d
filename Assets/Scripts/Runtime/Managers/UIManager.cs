using Runtime.Enums;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour, ISubscribe
    {
        public void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnLevelFailed()
        {
            CoreUISignals.Instance.onOpenPanel.Invoke(UIPanelTypes.Fail, SelectedLayer.Layer0,true);
        }

        private void OnLevelSuccessful()
        {
            CoreUISignals.Instance.onOpenPanel.Invoke(UIPanelTypes.Win, SelectedLayer.Layer0,true);
        }

        private void OnLevelInitialize(byte arg0)
        {
            CoreUISignals.Instance.onOpenPanel.Invoke(UIPanelTypes.Level, SelectedLayer.Layer0,true);
            UISignals.Instance.onSetLevelValue?.Invoke((byte)CoreGameSignals.Instance.onGetLevelValue?.Invoke());
        }

        private void OnReset()
        {
            CoreUISignals.Instance.onOpenPanel.Invoke(UIPanelTypes.Start, SelectedLayer.Layer0,true);
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
        }

        public void Play()
        {
            UISignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onOpenPanel(UIPanelTypes.Level, SelectedLayer.Layer2, true);
            InputSignals.Instance.onEnableInput?.Invoke();
            //CameraSignals.Instance.OnSetCameraTarget?.Invoke();
        }

        public void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}