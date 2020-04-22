using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitter
{
    void OnHit(RaycastHit hit);
}
