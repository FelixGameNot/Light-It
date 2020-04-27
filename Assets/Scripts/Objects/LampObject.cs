using System;
using System.Collections;
using Info;
using ScriptableObjects;
using UnityEngine;

namespace Objects
{
    public class LampObject : BaseObject
    {
        [SerializeField] private Light lamp;
        [SerializeField] private ColorChannels[] channels;
        [SerializeField] private BoolValue isOn;
        
        public override void Initialize(BaseInfo data)
        {
            transform.position = data.transformInfo.position;
            transform.eulerAngles = data.transformInfo.rotation;
            transform.localScale = data.transformInfo.scale;
            
            foreach(var ch in channels)
            {
                ch.OnChanged += RebuildTheColor;
            }
            RebuildTheColor();
        
            isOn.OnChanged += Fade;
            lamp.intensity = isOn.Value ? 1 : 0;
        }        
        
        private void OnDisable()
        {
            foreach(var ch in channels)
            {
                ch.OnChanged -= RebuildTheColor;
            }
            
            isOn.OnChanged -= Fade;
        }

        private void Fade() => StartCoroutine(Fade(isOn.Value));

        private IEnumerator Fade(bool @in)
        {
            if(@in)
                for (var t = 0f; t <= 1f; t += Time.fixedDeltaTime)
                {
                    lamp.intensity = t;
                    yield return new WaitForFixedUpdate();
                }
            else
                for (var t = 1f; t >= 0f; t -= Time.fixedDeltaTime)
                {
                    lamp.intensity = t;
                    yield return new WaitForFixedUpdate();
                }
        }
    
        public void RebuildTheColor()
        {
            lamp.color = new Color(channels[0].Value, channels[1].Value, channels[2].Value);
        }



        public override void Remove()
        {
            onRemove?.Invoke();
            Destroy(gameObject);
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