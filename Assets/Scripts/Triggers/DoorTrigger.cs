using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DoorTrigger : MonoBehaviour, IHitter
{
    public Animator anim;
    private bool _play;

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
        if (!_play)
        {
            anim.SetTrigger("OpenDoor");
            PlayAudio();
            Invoke("PlayAudio", 4f);
        }
    }

    private void PlayAudio()
    {
        AudioManager.instance.Play("Door");

    }
}
