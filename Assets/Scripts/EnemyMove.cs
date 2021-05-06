using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    #region properties

    public float EnemySpeed;

    #endregion properties



    #region fields

    private Transform _playerTransform;
    private Transform _enemyTransform;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
        _enemyTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 delta = player.position - _transform.position;
        Vector3 target = new Vector3(_playerTransform.position.x, _enemyTransform.position.y, _playerTransform.position.z);
        _enemyTransform.LookAt(target);
        _enemyTransform.position += _enemyTransform.forward * Time.deltaTime * EnemySpeed;
    }

    #endregion unity messages



    #region private methods


    #endregion private methods
}
