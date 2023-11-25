using Runtime.Abstract;
using Runtime.Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals : SingletonDontDestroyMonoObject<InputSignals>
    {
        public UnityAction onEnableInput = delegate {  };
        public UnityAction onDisableInput = delegate {  };
        public UnityAction onFirstTimeTouchTaken = delegate {  };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction onInputReleased = delegate {  };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate {  };
    }
}