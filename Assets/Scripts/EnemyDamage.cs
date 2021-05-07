using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    #region properties

    public IntVariable _enemyStartHP;
    public IntVariable _StunCount;
    public float HitDelay;

    #endregion properties



    #region fields

    private Transform _transform;
    [SerializeField] float _impactForce;
    private float _delayBeforeImpact;
    private Rigidbody _transformRB;
    private int _health;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    void Start()
    {
        _transform = transform;
        _health = _enemyStartHP.value;
        _delayBeforeImpact = Time.time;
        _transformRB = _transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!(Time.time >= _delayBeforeImpact)) return;
        if(collision.gameObject.tag == "Tree" && collision.relativeVelocity.magnitude > _impactForce )
        {
                _transformRB.velocity = Vector3.zero;

            _health -= 50;

            if (_health <= 0)
            {
                Destroy(_transform.gameObject);
                _StunCount.value++;
            }
                _delayBeforeImpact = Time.time + HitDelay;
                Debug.Log(_health);
        }
        
    }

    #endregion unity messages



    #region private methods


    #endregion private methods
}
