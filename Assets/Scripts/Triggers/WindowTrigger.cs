using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour, IHitter
{

    public Animator anim;
    public void OnHit(RaycastHit hit)
    {
        anim.SetTrigger("Click");
    }
}
