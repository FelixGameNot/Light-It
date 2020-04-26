using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace Objects
{
    public class LampObject : BaseObject
    {
        [SerializeField] private Light lamp;
        [SerializeField] private ColorChannels[] channels;
        [SerializeField] private BoolValue isOn;
        
        private void OnEnable()
        {
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

        public override void Initialize(string data)
        {
            throw new System.NotImplementedException();
        }

        public override string GetSerializedInfo()
        {
            throw new System.NotImplementedException();
        }

        public override void Remove()
        {
            base.Remove();
            Destroy(gameObject);
        }
    }
}