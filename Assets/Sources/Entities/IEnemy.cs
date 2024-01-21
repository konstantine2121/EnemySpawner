using UnityEngine;

namespace Assets.Sources.Entities
{
    public interface IEnemy
    {
        void SetTarget(Vector3? direction);
    }
}
