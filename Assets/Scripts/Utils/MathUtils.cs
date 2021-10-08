using UnityEngine;

namespace Utils
{
    public static class MathUtils
    {
        public static Vector3 Vector3Copy(Vector3 original)
        {
            return new Vector3(original.x, original.y, original.z);
        }
    }
}
