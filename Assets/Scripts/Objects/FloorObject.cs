using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(BoxCollider))]
    public class FloorObject : BaseObject
    {
        [SerializeField] private Transform tr;
        
        private Vector3 _newPosition;

        public override void OnClicked(RaycastHit hit)
        {
            _newPosition = new Vector3(hit.point.x, tr.position.y, hit.point.z);
            tr.position = _newPosition;
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
