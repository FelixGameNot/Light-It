using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MovementTrigger : MonoBehaviour, IHitter
{
    private Vector3 newPosition;
    public Transform tr;

    public void OnHit(RaycastHit hit)
    {
        newPosition = new Vector3(hit.point.x, tr.position.y, hit.point.z);
        tr.position = newPosition;
    }
}
