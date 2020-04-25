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

        public override void Initialize(string data)
        {
            throw new System.NotImplementedException();
        }

        public override string GetSerializedInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}
