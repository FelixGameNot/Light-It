using ScriptableObjects;
using UnityEngine;

namespace Objects
{
    public class DimmerObject : BaseObject
    {
        [SerializeField] private float speed;

        [SerializeField] private ColorChannels channel;

        [SerializeField] private Transform circle;

        private void Start()
        {
            circle.rotation = Quaternion.Euler(270f - channel.Value * 180, -90f, -90f);
        }

        public override void OnViewed()
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
