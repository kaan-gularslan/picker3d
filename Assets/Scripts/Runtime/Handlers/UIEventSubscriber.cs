using System;
using Runtime.Enums;
using Runtime.Interfaces;
using Runtime.Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Handlers
{
    [RequireComponent(typeof(Button))]
    public class UIEventSubscriber : MonoBehaviour, ISubscribe
    {
        [SerializeField] private UIEventSubscriptionType _type;
        private Button _buttton;
        private UIManager _manager;

        private void Awake()
        {
            GetReferences();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void GetReferences()
        {
            _manager = FindObjectOfType<UIManager>();
            _buttton = transform.GetComponent<Button>();
        }


        public void SubscribeEvents()
        {
            switch (_type)
            {
                case UIEventSubscriptionType.OnPlay:
                    _buttton.onClick.AddListener(_manager.Play);
                    break;
                case UIEventSubscriptionType.OnNextLevel:
                    _buttton.onClick.AddListener(_manager.NextLevel);
                    break;
                case UIEventSubscriptionType.OnRestartLevel:
                    _buttton.onClick.AddListener(_manager.RestartLevel);
                    break;
            }
        }

        public void UnsubscribeEvents()
        {
            _buttton.onClick.RemoveAllListeners();
        }
    }
}