using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyMovement enemy))
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}