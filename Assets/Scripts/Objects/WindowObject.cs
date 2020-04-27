using System;
using Info;
using UnityEngine;

namespace Objects
{
    public class WindowObject : BaseObject
    {
        [SerializeField] private Animator anim;
        private static readonly int Click = Animator.StringToHash("Click");
        private bool _isOpen;
        
        public override void Initialize(BaseInfo data)
        {
            if (data is WindowInfo cache)
            {
                Debug.Log("WindowOk");
                transform.position = cache.transformInfo.position;
                transform.eulerAngles = cache.transformInfo.rotation;
                transform.localScale = cache.transformInfo.scale;
                _isOpen = cache.isOpen;
                anim.Play(cache.isOpen ? "Open" : "Close");
            }
        }

        public override void OnClicked(RaycastHit hit)
        {
            anim.SetTrigger(Click);
            _isOpen = !_isOpen;
        }

        public override void Remove()
        {
            
        }
        
        public override BaseInfo GetInfo()
        {
            var info = new WindowInfo()
            {
                transformInfo = new TransformInfo()
                {
                    position = transform.position,
                    rotation = transform.eulerAngles,
                    scale = transform.localScale
                },
                isOpen = _isOpen
            };
            Debug.Log(info.isOpen);
            return info;
        }
    }
}
