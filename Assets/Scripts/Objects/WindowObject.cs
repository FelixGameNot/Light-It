using UnityEngine;

namespace Objects
{
    public class WindowObject : BaseObject
    {
        [SerializeField] private Animator anim;
        private static readonly int Click = Animator.StringToHash("Click");

        public override void OnClicked(RaycastHit hit)
        {
            anim.SetTrigger(Click);
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
