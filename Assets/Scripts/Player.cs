using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region properties

    public GameObject Saber;
    public float Speed;
    public float MouseSensitivity;

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
        float LookX = Input.GetAxis("Mouse X");



        Vector3 movement = new Vector3(AxisX, 0, AxisZ);

        if(Input.GetMouseButtonDown(0))
        {
            _saberAttack.Play();
        }

        movement.Normalize();

        movement = movement * Speed *Time.deltaTime;

        

        
        _playerRigidBody.rotation = Quaternion.Euler(_playerRigidBody.rotation.eulerAngles + new Vector3(0f, MouseSensitivity * LookX, 0f));
        _playerRigidBody.position += movement;
    }

    #endregion private methods
}
