using Runtime.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals : SingletonDontDestroyMonoObject<UISignals>
    {
        public UnityAction<byte> onSetStageColor = delegate {  };
        public UnityAction<byte> onSetLevelValue = delegate {  };
        public UnityAction onPlay = delegate {  };
    }
}