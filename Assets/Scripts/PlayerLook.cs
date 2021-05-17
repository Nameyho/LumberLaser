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
    [SerializeField] private Transform _playerCamera;
    
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
        float LookY = -Input.GetAxis("Mouse Y");

        


        var yRotate = LookY * MouseSensitivity ;
        
        

        
        _playerTransform.RotateAround(_playerTransform.position, Vector3.up, MouseSensitivity * LookX);
        _playerCamera.RotateAround(_playerCamera.position, _playerCamera.right, yRotate);

        // float minAngle = -90f;
        // float maxAngle = 90f;
        Vector3 eulerRotation = _playerCamera.rotation.eulerAngles;
        // eulerRotation.x = Mathf.Clamp(eulerRotation.x, minAngle, maxAngle);
        // _playerCamera.rotation = Quaternion.Euler(eulerRotation);
    }

    #endregion private methods
}
