using UnityEngine;

namespace Runtime.Abstract
{
    public abstract class SingletonMonoObject<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; protected set; }
        protected virtual void Awake()
        {
            SetSingletonMono();
        }

        protected abstract void SetSingletonMono();
    }
    public abstract class SingletonDestroyMonoObject<T> : SingletonMonoObject<T> where T : MonoBehaviour
    {
        protected override void SetSingletonMono()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    
    public abstract class SingletonDontDestroyMonoObject<T> : SingletonMonoObject<T> where T : MonoBehaviour
    {
        protected override void SetSingletonMono()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}