using Runtime.Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public static InputSignals Instance { get; private set; }
        public UnityAction onEnableInput = delegate {  };
        public UnityAction onDisableInput = delegate {  };
        public UnityAction onFirstTimeTouchTaken = delegate {  };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction onInputReleased = delegate {  };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate {  };
        
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