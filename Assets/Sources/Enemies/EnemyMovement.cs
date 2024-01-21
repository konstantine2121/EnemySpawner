using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent (typeof (Rigidbody))]
    public class EnemyMovement : MonoBehaviour, IEnemy
    {
        [SerializeField][Range(0, 200)]
        private float _movementSpeed = 0.5f;
        
        private Vector3? _target;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetTarget(Vector3? target)
        {
            _target = target;
        }
        
        private void FixedUpdate() 
        {
            _rigidbody.velocity = Vector3.zero;

            if (_target.HasValue)
            {
                var pathToTarget = _target.Value - transform.position;
                var direction = pathToTarget.normalized;
                
                _rigidbody.AddForce(direction * _movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
}