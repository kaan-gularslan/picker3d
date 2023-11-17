using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public UnityAction<byte> onLevelInitialize = delegate{ };
        public UnityAction onLevelDestroy = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onRestartLevel = delegate {  };
        public UnityAction onClearActiveLevel = delegate {  };
        public Func<byte> onGetLevelValue = delegate { return 0; };
        public UnityAction onReset = delegate {  };
        public static CoreGameSignals Instance { get; private set; }

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