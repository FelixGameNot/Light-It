using System.Collections;
using Audio;
using Info;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(BoxCollider))]
    public class DoorObject : BaseObject
    {
        [SerializeField] private Animator anim;
        
        private bool _play;
        private static readonly int OpenDoor = Animator.StringToHash("OpenDoor");

        public override void Initialize(BaseInfo data)
        {
            transform.position = data.transformInfo.position;
            transform.eulerAngles = data.transformInfo.rotation;
            transform.localScale = data.transformInfo.scale;
        }
        
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

        public override void Remove()
        {
            
        }

        public override BaseInfo GetInfo()
        {
            return new BaseInfo()
            {
                transformInfo = new TransformInfo()
                {
                    position = transform.position,
                    rotation = transform.eulerAngles,
                    scale = transform.localScale
                }
            };
        }

    }
}
