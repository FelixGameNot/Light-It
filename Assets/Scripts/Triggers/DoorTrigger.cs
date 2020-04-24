using System.Collections;
using Interfaces;
using UnityEngine;
using Audio;

namespace Triggers
{
    [RequireComponent(typeof(BoxCollider))]
    public class DoorTrigger : MonoBehaviour, IHitter
    {
        [SerializeField] private Animator anim;
        
        private bool _play;
        private static readonly int OpenDoor = Animator.StringToHash("OpenDoor");

        public void AnimIsPlaying()
        {
            _play = true;
        }    
    
        public void AnimIsEnding()
        {
            _play = false;
        }

        public void OnHit(RaycastHit hit)
        {
            if (_play) return;
            
            anim.SetTrigger(OpenDoor);

            StartCoroutine(PlayAudio());
        }

        private static IEnumerator PlayAudio()
        {
            AudioManager.Instance.Play("Door");
            yield return new WaitForSeconds(4f);
            AudioManager.Instance.Play("Door");
        }
        
    }
}
