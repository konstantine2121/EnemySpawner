using System.Collections;
using System.Linq;
using Assets.Sources.Enemies;
using Assets.Sources.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Sources.Spawn
{
    public class Spawner : MonoBehaviour
    {
        #region Fields

        [SerializeField][Range(1, 5)] private float _spawnInterval = 2;
        [SerializeField] private EnemyMovement _enemyPrefab;
        [SerializeField] private Transform _target = null;

        private ISpawnPoint[] _spawnPoints;
        private bool _isSpawning;
        private Coroutine spawnCoroutine;

        #endregion Fields

        #region Unity Events

        private void Awake()
        {
            _spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None)
                .Cast<ISpawnPoint>()
                .ToArray();
        }

        private void OnEnable()
        {
            EnableSpawning();
        }

        private void OnDisable()
        {
            DisableSpawning();
        }

        #endregion Unity Actions

        #region Spawn

        private IEnemy SpawnEnemy()
        {
            var spawnPoint = GetRandomSpawnPoint();

            if (!_isSpawning ||
                _enemyPrefab == null ||
                spawnPoint is null)
            {
                return null;
            }

            return Instantiate(
                _enemyPrefab, 
                spawnPoint.Position, 
                Quaternion.identity);
        }

        private ISpawnPoint GetRandomSpawnPoint()
        {
            return _spawnPoints.Length > 0 ?
                _spawnPoints[Random.Range(0, _spawnPoints.Length)] :
                null;
        }

        private void SetEnemyMovementDirection(IEnemy enemy)
        {
            if (enemy == null || _target == null)
            {
                return;
            }

            enemy.SetMovementDirection(enemy.Position.GetDirection(_target.position));
        }


        #endregion Spawn

        #region Enable/ Disable Spawn

        private void EnableSpawning()
        {
            DisableSpawning();

            _isSpawning = true;
            spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private void DisableSpawning()
        {
            _isSpawning = false;

            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
        }


        private IEnumerator SpawnCoroutine()
        {
            var delay = new WaitForSeconds(_spawnInterval);

            do
            {
                yield return delay;

                SetEnemyMovementDirection(SpawnEnemy());
            }
            while (_isSpawning && enabled);
        }

        #endregion Enable/ Disable Spawn
    }
}