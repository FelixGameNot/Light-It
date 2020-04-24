using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Triggers
{
    public class DimmerTrigger : MonoBehaviour, IWatcher
    {
        [SerializeField] private float speed;

        [SerializeField] private ColorChannels channel;

        [SerializeField] private Transform circle;

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
        }
    }
}
