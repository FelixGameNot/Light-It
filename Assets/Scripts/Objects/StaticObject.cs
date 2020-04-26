using System;

namespace Objects
{
    public class StaticObject : BaseObject
    {
        public override void Initialize(string data)
        {
            throw new NotImplementedException();
        }

        public override string GetSerializedInfo()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            base.Remove();
            Destroy(gameObject);
        }
    }
}