using Runtime.Abstract;
using Runtime.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreUISignals : SingletonDontDestroyMonoObject<CoreUISignals>
    {
        public UnityAction<UIPanelTypes, SelectedLayer, bool> onOpenPanel = delegate { };
        public UnityAction<UIPanelTypes> onClosePanel = delegate { };
        public UnityAction onCloseAllPanels = delegate { };
    }
}