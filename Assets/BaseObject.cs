using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{

    public abstract void Initialize(string data);

    public abstract string GetSerializedInfo();

    public virtual void OnViewed(){}
    public virtual void OnClicked(RaycastHit hit){ }

    public virtual void OnStartHandling(){ }

    public virtual void OnEndHandling() { }

}
