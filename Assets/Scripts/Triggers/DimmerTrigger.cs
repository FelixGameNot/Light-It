using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerTrigger : MonoBehaviour, IWatcher
{

    public float speed;

    public ColorChannels channel;

    public Transform circle;

    private void Start()
    {
        circle.rotation = Quaternion.Euler(270f - channel.Value * 180, -90f, -90f);
    }

    public void OnWatch()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            channel.Value += speed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            channel.Value -= speed * Time.deltaTime;
        }
        circle.rotation = Quaternion.Euler(270f-channel.Value*180, -90f, -90f);
        Debug.Log(channel.Value);
    }
}
