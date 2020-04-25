using System.Collections;
using Audio;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(BoxCollider))]
    public class DoorObject : BaseObject
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
        
        public override void OnClicked(RaycastHit hit)
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
