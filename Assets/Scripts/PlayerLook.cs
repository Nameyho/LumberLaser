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
    private Transform _playerCamera;
    
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
        _playerCamera = GameObject.Find("Main Camera").transform;
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
        float LookY = -Input.GetAxis("Mouse Y");

        

        float minAngle = -90f;
        float maxAngle = 90f;

        var yRotate = LookY * MouseSensitivity ;
        
        
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);

        
        _playerTransform.RotateAround(_playerTransform.position, Vector3.up, MouseSensitivity * LookX);

        //_playerCamera.RotateAround(_playerCamera.position, _playerCamera.right, yRotate);

        
    }

    #endregion private methods
}
