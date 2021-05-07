using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region properties

    public IntVariable _enemiesLeft;

    #endregion properties



    #region fields

    private Text _enemyCountText;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    void Start()
    {
        _enemiesLeft.value = Random.Range(1, 10);
        _enemyCountText = GameObject.Find("EnemyCounterGui").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        GUIUpdate();
        CheckEndGame();

    }

    #endregion unity messages



    #region private methods

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

    #endregion private methods
}
