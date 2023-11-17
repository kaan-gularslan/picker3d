using System;
using System.Collections.Generic;
using Runtime.Enums;
using Runtime.Interfaces;
using Runtime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Controllers
{
    public class UIPanelController : MonoBehaviour, ISubscribe
    {
        private Dictionary<UIPanelTypes, GameObject> _openedPanels = new Dictionary<UIPanelTypes, GameObject>();
        private List<Transform> _layers = new List<Transform>();

        private void Awake()
        {
            CreateLayers();
        }

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
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }

        public void UnsubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanels -= OnCloseAllPanels;
        }

        private void CreateLayers()
        {
#if UNITY_EDITOR
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

#else
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }

#endif
            _layers.Clear();
            int layerCount = Enum.GetValues(typeof(SelectedLayer)).Length;
            for (int i = 0; i < layerCount; i++)
            {
                GameObject createdLayer = Instantiate(Resources.Load<GameObject>($"UI/UIPanelController/Empty Layer"),
                    this.transform);
                createdLayer.name = $"Layer {i}";
                _layers.Add(createdLayer.transform);
            }
        }

        private void OnOpenPanel(UIPanelTypes panelType, SelectedLayer selectedLayer)
        {
            if (_openedPanels.ContainsKey(panelType))
            {
                Debug.LogWarning("Bu panel zaten açık!");
                return;
            }

            GameObject createdPanel =
                Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"), _layers[(int)selectedLayer]);
            _openedPanels.Add(panelType, createdPanel);
        }

        private void OnClosePanel(UIPanelTypes panelType)
        {
            if (_openedPanels.ContainsKey(panelType))
            {
#if UNITY_EDITOR
                DestroyImmediate(_openedPanels[panelType]);
#endif
                Destroy(_openedPanels[panelType]);
            }

            _openedPanels.Remove(panelType);
        }

        private void OnCloseAllPanels()
        {
            if (_openedPanels.Count <= 0) return;
            foreach (var openedPanel in _openedPanels)
            {
                Destroy(openedPanel.Value);
            }

            _openedPanels.Clear();
        }
    }
}