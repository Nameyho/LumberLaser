using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region properties


    public IntVariable StunCount;
    public int EnemyAmount;

    #endregion properties



    #region fields

    private int _enemiesLeft;
    [SerializeField] private GameObject _gameGUI;
    [SerializeField] private GameObject _WinGUI;
    private bool IsWin;
    private bool IsLost;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    void Start()
    {
        _gameGUI.SetActive(true);
        _WinGUI.SetActive(false);
    }

    private void LateUpdate()
    {
        CheckWin();
        CheckLose();
    }

    #endregion unity messages



    #region private methods

    private void CheckWin()
    {
        if (StunCount.value == EnemyAmount && IsWin == false)
        {
            _gameGUI.SetActive(false);
            _WinGUI.SetActive(true);
            IsWin = true;
        }
    }

    private void CheckLose()
    {

    }


    #endregion private methods
}
