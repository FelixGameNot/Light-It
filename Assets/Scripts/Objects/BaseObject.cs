using System;
using Info;
using UnityEngine;

namespace Objects
{
    public abstract class BaseObject : MonoBehaviour
    {

        public readonly Type type;
        
        public Action onRemove;
    
        public abstract void Initialize(string data);
        public abstract string GetSerializedInfo();

        public virtual void OnViewed() { }
        public virtual void OnClicked(RaycastHit hit) { }

        public virtual void OnStartHandling(RaycastHit hit) { }

        public virtual void OnHandling(RaycastHit hit) { }

        public virtual void OnEndHandling(RaycastHit hit) { }

        public virtual void Remove()
        {
            onRemove?.Invoke();
        }

        public virtual BaseInfo GetInfo()
        {
            return new BaseInfo();
        }

    }
}
