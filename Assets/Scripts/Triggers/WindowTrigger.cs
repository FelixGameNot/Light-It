using Interfaces;
using UnityEngine;

namespace Triggers
{
    public class WindowTrigger : MonoBehaviour, IHitter
    {
        [SerializeField] private Animator anim;
        private static readonly int Click = Animator.StringToHash("Click");

        public void OnHit(RaycastHit hit)
        {
            anim.SetTrigger(Click);
        }
    }
}
