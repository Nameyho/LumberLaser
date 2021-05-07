using System.Collections;
<<<<<<< HEAD
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
=======

using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
>>>>>>> 1602be7da3acdb4ba881f9da1823723d783bd0d7

public class GameManager : MonoBehaviour
{
    #region properties

<<<<<<< HEAD
    
    public IntVariable StunCount;
    public int EnemyAmount;
=======
    public IntVariable _enemiesLeft;
>>>>>>> 1602be7da3acdb4ba881f9da1823723d783bd0d7

    #endregion properties



    #region fields

<<<<<<< HEAD
    private int _enemiesLeft;
    [SerializeField] private GameObject _gameGUI;
    [SerializeField] private GameObject _WinGUI;
    private bool IsWin;
    private bool IsLost;
=======
    private Text _enemyCountText;
>>>>>>> 1602be7da3acdb4ba881f9da1823723d783bd0d7

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    void Start()
    {
<<<<<<< HEAD
        _gameGUI.SetActive(true);
        _WinGUI.SetActive(false);
    }

    private void LateUpdate()
    {
        CheckWin();
        CheckLose();
=======
        _enemiesLeft.value = Random.Range(1, 10);
        _enemyCountText = GameObject.Find("EnemyCounterGui").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        GUIUpdate();
        CheckEndGame();

>>>>>>> 1602be7da3acdb4ba881f9da1823723d783bd0d7
    }

    #endregion unity messages



    #region private methods

<<<<<<< HEAD
    private void CheckWin()
    {
        if(StunCount.value == EnemyAmount && IsWin == false)
        {
            _gameGUI.SetActive(false);
            _WinGUI.SetActive(true);
            IsWin = true;
        }
    }

    private void CheckLose()
    {

    }


=======
    private void GUIUpdate()
    {
        _enemyCountText.text = "Enemies left : " + _enemiesLeft.value;
    }

    private void CheckEndGame()
    {
        if(_enemiesLeft.value == 0)
        {
            Debug.Log("Partie gagnée");
        }
    }

>>>>>>> 1602be7da3acdb4ba881f9da1823723d783bd0d7
    #endregion private methods
}
