using UnityEngine;

namespace Assets.Sources.Enemies
{
    public interface IEnemy
    {
        void SetMovementDirection(Vector3? targetPosition);
    }
}
