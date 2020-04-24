using Interfaces;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(BoxCollider))]
    public class MovementTrigger : MonoBehaviour, IHitter
    {
        [SerializeField] private Transform tr;
        
        private Vector3 _newPosition;

        public void OnHit(RaycastHit hit)
        {
            _newPosition = new Vector3(hit.point.x, tr.position.y, hit.point.z);
            tr.position = _newPosition;
        }
    }
}
