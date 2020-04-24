using UnityEngine;

namespace Interfaces
{
    public interface IHitter
    {
        void OnHit(RaycastHit hit);
    }
}
