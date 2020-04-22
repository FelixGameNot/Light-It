using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour, IHitter
{

    public Animator anim;
    public BoolValue bv;
    public void OnHit(RaycastHit hit)
    {
        anim.SetTrigger("Click");
        bv.Value = !bv.Value;
        AudioManager.instance.Play("Click");
    }

}
