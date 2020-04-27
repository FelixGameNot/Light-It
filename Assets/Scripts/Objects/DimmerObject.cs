using System.Collections.Generic;
using Info;
using ScriptableObjects;
using UnityEngine;

namespace Objects
{
    public class DimmerObject : BaseObject
    {
        [SerializeField] private float speed;

        [SerializeField] private ColorChannels channel;

        [SerializeField] private Transform circle;
        
        public override void Initialize(BaseInfo data)
        {
            if (data is DimmerInfo cache)
            {
                transform.position = cache.transformInfo.position;
                transform.eulerAngles = cache.transformInfo.rotation;
                transform.localScale = cache.transformInfo.scale;
                channel.Value = cache.dimmerValue;
                circle.rotation = Quaternion.Euler(270f - channel.Value * 180, -90f, -90f);
            }
        }
        
        public override void OnViewed()
        {
            base.OnViewed();
            if(Input.mouseScrollDelta.y > 0 || Input.GetMouseButton(1))
            {
                channel.Value += speed * Time.deltaTime;
            }
            if (Input.mouseScrollDelta.y < 0 || Input.GetMouseButton(0))
            {
                channel.Value -= speed * Time.deltaTime;
            }
            circle.rotation = Quaternion.Euler(270f-channel.Value*180, -90f, -90f);
        }
        
        public override BaseInfo GetInfo()
        {
            return new DimmerInfo()
            {
                transformInfo = new TransformInfo()
                {
                    position = transform.position,
                    rotation = transform.eulerAngles,
                    scale = transform.localScale
                },
                dimmerValue = channel.Value
            };
        }
        
    }
}
