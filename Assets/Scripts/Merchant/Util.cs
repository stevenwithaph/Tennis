using UnityEngine;
using System.Collections;

namespace Merchant
{
    public static class Util
    {
        public static GameObject CreateChildGameobject(GameObject parent, string name)
        {
            GameObject child = new GameObject(name);
            
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
            return child;
        }
    }
}
