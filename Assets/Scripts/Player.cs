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

    private Animation _saberAttack;
    private Transform _transform;
    
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
        _transform = transform ;
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



        Vector3 movement = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            _saberAttack.Play();
        }


        movement = new Vector3(AxisX, 0f, AxisZ);

        Vector3 newdir = _transform.TransformDirection(movement);


        _transform.rotation = Quaternion.Euler(_transform.rotation.eulerAngles + new Vector3(0f, MouseSensitivity * LookX, 0f));




        _transform.position += newdir.normalized * Speed * Time.deltaTime;
    }

    #endregion private methods
}
