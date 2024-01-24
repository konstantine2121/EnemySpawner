using UnityEngine;

namespace Assets.Sources.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 GetDirection(this Vector3 from, Vector3 to)
        {
            var heading = to - from;
            return heading.normalized;
        }

        public static Vector3? GetDirection(this Vector3? from, Vector3? to)
        {
            return from.HasValue && to.HasValue ?
                GetDirection(from.Value, to.Value) :
                null;
        }
    }
}
