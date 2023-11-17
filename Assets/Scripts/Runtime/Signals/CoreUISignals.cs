using Runtime.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreUISignals : MonoBehaviour
    {
        public static CoreUISignals Instance { get; private set; }
        public UnityAction<UIPanelTypes, SelectedLayer> onOpenPanel = delegate {  };
        public UnityAction<UIPanelTypes> onClosePanel = delegate {  };
        public UnityAction onCloseAllPanels = delegate {  };


        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy((this.gameObject));
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}