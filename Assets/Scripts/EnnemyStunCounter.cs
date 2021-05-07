using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyStunCounter : MonoBehaviour
{

    #region fields

    private Text _Changingtext;
    public IntVariable _CurrentStunCount;

    #endregion
    #region unity message


    private void Update()
    {
        ShowCounter();   
    }

    private void Start()
    {
        _Changingtext = GetComponent<Text>();
        _CurrentStunCount.value =0 ;
    }
    #endregion


    #region private methods

    public void ShowCounter()
    {
        _Changingtext.text = _CurrentStunCount.value + " assommés";
    }

    #endregion
}
