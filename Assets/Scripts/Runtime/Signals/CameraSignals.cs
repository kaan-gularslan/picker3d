using Runtime.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CameraSignals : SingletonDontDestroyMonoObject<CameraSignals>
    {
        public UnityAction onSetCameraTarget = delegate {  };
    }
}