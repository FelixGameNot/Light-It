using System;
using System.Collections;
using UnityEngine;

namespace Info
{
    [Serializable]
    public class BaseInfo
    {
        public TransformInfo transformInfo;
    }

    [Serializable]
    public class WindowInfo : BaseInfo
    {
        public float eschoChtoTo;
    }

    [Serializable]
    public class TransformInfo
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }
}