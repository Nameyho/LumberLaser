using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    #region properties

    public float SpawnTime;
    public IntVariable EnemiesToSpawn;

    #endregion properties



    #region fields

    private Transform _playerTransform;
    [SerializeField] private List<Transform> _spawners;
    [SerializeField] private Transform _enemyPrefab;
    
    private float _nextSpawnTime;
    private int _enemiesLeftToSpawn;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    private void Start()
    {
        _nextSpawnTime = 0f;
        _enemiesLeftToSpawn = EnemiesToSpawn.value;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= _nextSpawnTime && _enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + SpawnTime;
            _enemiesLeftToSpawn--;
        }
    }

    private void SpawnEnemy()
    {

        Vector3 randomPosition = _spawners[Random.Range(0, _spawners.Count)].position;
        Instantiate(_enemyPrefab, randomPosition + Vector3.up * _enemyPrefab.localScale.y, Quaternion.identity);
       
    }

    #endregion unity messages



    #region private methods


    #endregion private methods
}
