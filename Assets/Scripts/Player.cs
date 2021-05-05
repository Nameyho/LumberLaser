using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region properties

    public GameObject Saber;
    public float Speed;

    #endregion properties



    #region fields

    private bool IsAnimPlaying;
    private Animation _saberAttack;
    private Rigidbody _playerRigidBody;
    
    #endregion fields



    #region public methods
    
    #endregion public methods



    #region unity messages
    private void Awake()
    {
        _saberAttack = Saber.gameObject.GetComponent<Animation>();
        
    }

    private void Start()
    {
        _playerRigidBody = transform.GetComponent<Rigidbody>(); ;
    }

    private void Update()
    {
        DetectInput();
        
    }

    #endregion unity messages



    #region private methods

    private void DetectInput()
    {
        Vector3 direction = Vector3.zero;

        float AxisX = Input.GetAxis("Horizontal");
        float AxisZ = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(AxisX, 0, AxisZ);

        if(Input.GetMouseButtonDown(0))
        {
            _saberAttack.Play();
        }

        velocity.Normalize();

        velocity = velocity * Speed;

        _playerRigidBody.velocity = velocity;

    }

    #endregion private methods
}
