using Info;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(BoxCollider))]
    public class FloorObject : BaseObject
    {
        [SerializeField] private Transform tr;
        
        private Vector3 _newPosition;
        
        public override void Initialize(BaseInfo data)
        {
            transform.position = data.transformInfo.position;
            transform.eulerAngles = data.transformInfo.rotation;
            transform.localScale = data.transformInfo.scale;
            tr = Camera.main.transform;
        }
        
        public override void OnClicked(RaycastHit hit)
        {
            _newPosition = new Vector3(hit.point.x, tr.position.y, hit.point.z);
            tr.position = _newPosition;
        }
        
        public override void Remove()
        {
            
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
