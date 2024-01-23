using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent (typeof (Rigidbody))]
    public class EnemyMovement : MonoBehaviour, IEnemy
    {
        #region Fields

        [SerializeField, Range(0, 200)] private float _movementSpeed = 0.5f;
        
        private Vector3? _direction;
        private Rigidbody _rigidbody;

        #endregion Fields

        #region Unity Events

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector3.zero;

            if (_direction.HasValue)
            {
                _rigidbody.AddForce(_direction.Value * _movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }

        #endregion Unity Events

        #region IEnemy Implementation

        public void SetMovementDirection(Vector3? targetPosition)
        {
            if (targetPosition.HasValue)
            {
                var pathToTarget = targetPosition.Value - transform.position;
                _direction = pathToTarget.normalized;
            }
            else
            {
                _direction = null;
            }
        }

        #endregion IEnemy Implementation
    }
}