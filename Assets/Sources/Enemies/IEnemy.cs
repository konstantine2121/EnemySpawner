using UnityEngine;

namespace Assets.Sources.Enemies
{
    public interface IEnemy : IPositionProvider
    {
        void SetMovementDirection(Vector3? direction);
    }
}