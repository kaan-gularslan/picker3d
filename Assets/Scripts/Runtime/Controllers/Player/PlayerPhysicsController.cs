using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        [SerializeField] private PlayerManager _manager;
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;

        private const string STAGE_AREA = "StageArea";
        private const string FINISH_AREA = "FinishArea";
        private const string MINI_GAME_AREA = "MiniGameArea";
        
        void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(STAGE_AREA))
            {
                _manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                
                // Stage Area Kontrol Süreci
            }

            if (other.CompareTag(FINISH_AREA))
            {
                CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }

            if (other.CompareTag(MINI_GAME_AREA))
            {
                // Minigame mekanikleri buraya yapılacak 
            }
            
        }
        
        public void OnReset()
        {
                
        }
    }
}