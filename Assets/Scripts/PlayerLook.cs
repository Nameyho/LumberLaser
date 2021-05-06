using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region properties

    public float MouseSensitivity;

    #endregion properties



    #region fields

    private Transform _playerTransform;
    
    #endregion fields



    #region public methods
    
    #endregion public methods



    #region unity messages
    private void Awake()
    {
        
        
    }

    private void Start()
    {
        _playerTransform = transform ;
    }

    private void Update()
    {
        DetectInput();
        
    }

    #endregion unity messages



    #region private methods

    private void DetectInput()
    {
       
        float LookX = Input.GetAxis("Mouse X");
        float LookY = Input.GetAxis("Mouse Y");

        _playerTransform.rotation = Quaternion.Euler(_playerTransform.rotation.eulerAngles + new Vector3(/*MouseSensitivity * LookY*/ 0f, MouseSensitivity * LookX, 0f));
        
    }

    #endregion private methods
}
