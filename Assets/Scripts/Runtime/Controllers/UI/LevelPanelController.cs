using System;
using System.Collections.Generic;
using DG.Tweening;
using Runtime.Interfaces;
using Runtime.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Sirenix.OdinInspector;

namespace Runtime.Controllers.UI
{
    public class LevelPanelController : MonoBehaviour, ISubscribe
    {
        [SerializeField] private List<Image> _stageImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> _levelTexts = new List<TextMeshProUGUI>();
        [SerializeField] private Color _stageColor;


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        public void SubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue += OnSetLevelValue;
            UISignals.Instance.onSetStageColor += OnSetStageColor;
            
        }
        [Button("SetStageColor")]
        private void OnSetStageColor(byte levelValue)
        {
            _stageImages[levelValue].DOColor(_stageColor, 0.5f);
        }

        private void OnSetLevelValue(byte levelValue)
        {
            _levelTexts[0].text = (levelValue + 1).ToString();
            _levelTexts[1].text = (levelValue + 2).ToString();

        }

        public void UnsubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue -= OnSetLevelValue;
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
        }
    }
}