using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpawner : MonoBehaviour
{
    #region fields
    [SerializeField] private float _delayBetweenSpawn;
    public GameObject _TreePrefab;
    private float _nextSpawnTime;
    #endregion

    #region Unity Message

    private void Start()
    {

    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnCylinder();
        }
    }
    #endregion

    #region Private Methodes

    public void SpawnCylinder()
    {
        _nextSpawnTime = Time.time + _delayBetweenSpawn;
        Vector3 randomPosition = new Vector3(Random.Range(-150, 150), 3, Random.Range(-100, 150));
        Instantiate(_TreePrefab, randomPosition, Quaternion.identity);
    }

    #endregion
}
