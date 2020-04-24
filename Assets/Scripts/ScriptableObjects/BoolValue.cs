using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName ="Bool",menuName ="Assets/BulVar")]
    public class BoolValue : ScriptableObject
    {
        public delegate void Rebuild();
        public event Rebuild OnChanged;

        private bool _value = true;
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;

                OnChanged?.Invoke();
            }
        }
    }
}
