using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region properties

    public GameObject Saber;
    
    #endregion properties


    #region fields

    
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
        

        if (Input.GetMouseButtonDown(0))
        {
            _saberAttack.Play();
        }

    }

    #endregion private methods
}
