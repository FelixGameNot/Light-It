using Info;
using ScriptableObjects;
using UnityEngine;

namespace Objects
{
    public class SwitchObject : BaseObject
    {
        [SerializeField] private Animator anim;
        [SerializeField] private BoolValue bv;
        private static readonly int Click = Animator.StringToHash("Click");

        public override void OnClicked(RaycastHit hit)
        {
            anim.SetTrigger(Click);
            bv.Value = !bv.Value;
            Audio.AudioManager.Instance.Play("Click");
        }

        public override void Initialize(BaseInfo data)
        {
            if (data is SwitchInfo cache)
            {
                Debug.Log("SwitchOk");
                transform.position = cache.transformInfo.position;
                transform.eulerAngles = cache.transformInfo.rotation;
                transform.localScale = cache.transformInfo.scale;
                bv.Value = cache.isOn;
                anim.Play(cache.isOn ? "Switch_On" : "Switch_Off");
            }
        }
        
        public override void Remove()
        {
            
        }
        
        public override BaseInfo GetInfo()
        {
            return new SwitchInfo()
            {
                transformInfo = new TransformInfo()
                {
                    position = transform.position,
                    rotation = transform.eulerAngles,
                    scale = transform.localScale
                },
                isOn = bv.Value
            };
        }
        
    }
}
