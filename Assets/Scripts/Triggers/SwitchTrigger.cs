using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Triggers
{
    public class SwitchTrigger : MonoBehaviour, IHitter
    {
        [SerializeField] private Animator anim;
        [SerializeField] private BoolValue bv;
        private static readonly int Click = Animator.StringToHash("Click");

        public void OnHit(RaycastHit hit)
        {
            anim.SetTrigger(Click);
            bv.Value = !bv.Value;
            Audio.AudioManager.Instance.Play("Click");
        }

    }
}
