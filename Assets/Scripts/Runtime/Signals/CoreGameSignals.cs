using System;
using Runtime.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : SingletonDontDestroyMonoObject<CoreGameSignals>
    {
        public UnityAction<byte> onLevelInitialize = delegate{ };
        public UnityAction onLevelDestroy = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onRestartLevel = delegate {  };
        public UnityAction onClearActiveLevel = delegate {  };
        public Func<byte> onGetLevelValue = delegate { return 0; };
        public UnityAction onReset = delegate {  };
        public UnityAction onLevelSuccessful = delegate {  };
        public UnityAction onLevelFailed = delegate {  };
        public UnityAction onStageAreaEntered = delegate {  };
        public UnityAction<byte> onStageAreaSuccessful = delegate {  };
        public UnityAction onFinishAreaEntered = delegate {  };
        
    }
}