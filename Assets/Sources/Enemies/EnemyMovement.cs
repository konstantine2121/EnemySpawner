using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent (typeof (Rigidbody))]
    public class EnemyMovement : MonoBehaviour, IEnemy
    {
        [SerializeField][Range(0, 200)] private float _movementSpeed = 0.5f;
        
        private Vector3? _direction;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetTarget(Vector3? target)
        {
            if (target.HasValue)
            {
                var pathToTarget = target.Value - transform.position;
                _direction = pathToTarget.normalized;
            }
            else
            {
                _direction = null;
            }
        }
        
        private void FixedUpdate() 
        {
            _rigidbody.velocity = Vector3.zero;

            if (_direction.HasValue)
            {   
                _rigidbody.AddForce(_direction.Value * _movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
}