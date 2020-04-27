using System;
using Info;
using UnityEngine;

namespace Objects
{
    public abstract class BaseObject : MonoBehaviour
    {

        public Type type;
        [SerializeField] protected new Transform transform;
        public Action onRemove;
    
        public abstract void Initialize(BaseInfo data);

        public virtual void OnViewed()
        {
            UiManager.Instance.viewedObjectText.SetText(gameObject.name);
        }
        public virtual void OnClicked(RaycastHit hit) { }

        public virtual void OnStartHandling(RaycastHit hit) { }

        public virtual void OnHandling(RaycastHit hit) { }

        public virtual void OnEndHandling(RaycastHit hit) { }

        public virtual void Remove() { }

        public virtual void ForceRemove()
        {
            onRemove?.Invoke();
            Destroy(gameObject);
        }

        public abstract BaseInfo GetInfo();
        
    }
}
