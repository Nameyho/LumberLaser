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
    private Transform _playerTransform;
    
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
        _playerTransform = transform;
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
        float AxisY = Input.GetAxis("Vertical");


        
        direction = direction.normalized;
        _playerTransform.Translate(direction * Time.deltaTime * Speed, Space.World);
    }

    #endregion private methods
}
