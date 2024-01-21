using UnityEngine;

namespace Assets.Sources.Spawn
{
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        public Vector3 Position => transform.position;
    }
}