using System;
using Info;

namespace Objects
{
    public class StaticObject : BaseObject
    {

        public override void Initialize(BaseInfo data)
        {
            transform.position = data.transformInfo.position;
            transform.eulerAngles = data.transformInfo.rotation;
            transform.localScale = data.transformInfo.scale;
        }

        public override void Remove()
        {
            onRemove?.Invoke();
            Destroy(gameObject);
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