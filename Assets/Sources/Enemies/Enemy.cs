using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent (typeof (Rigidbody))]
    public class Enemy : MonoBehaviour, IEnemy
    {
        private Vector3? _target;
        private Rigidbody _rigidbody;

        private float _movementSpeed = 0.5f;

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
                var pathToTarget = transform.position - _target.Value;
                var direction = pathToTarget.normalized;
                
                _rigidbody.AddForce(direction * _movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
}