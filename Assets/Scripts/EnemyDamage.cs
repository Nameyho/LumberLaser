using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    #region properties

    public IntVariable _enemyStartHP;
    public IntVariable _enemyCurrentHP;
    public IntVariable _StunCount;

    #endregion properties



    #region fields

    private Transform _transform;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    void Start()
    {
        _transform = transform;
        _enemyCurrentHP.value = _enemyStartHP.value;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tree")
        {
            

            _enemyCurrentHP.value -= 50;

            if (_enemyCurrentHP.value <= 0)
            {
                Destroy(_transform.gameObject);
                _StunCount.value++;
            }
        }
        
    }

    #endregion unity messages



    #region private methods


    #endregion private methods
}
