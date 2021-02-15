using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    //1 
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public bool showWinScreen = false;
    public string labelText = "Collect all 4 items and win your freedom and win your freedom!";
    public int maxItems = 4;
    private int _itemsCollected = 0;
    public bool showLossScreen = false;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            //2 
            RestartLevel();
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch...that's got hurt.";
            }
            showWinScreen = true;
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
            }
            else
            {
                labelText = "Item found, only" + (maxItems - _itemsCollected) + "more to go!";
            }
        }
    }
    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            //3 
            if (showLossScreen)
            {
                if (GUI.Button(new Rect(Screen.width /2 -100, Screen.height/2-50,200,100),"You lose..."))
                {
                    RestartLevel();
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                }
            }

            if (showWinScreen)
            {
                //4
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))

                    GUI.Box(new Rect(20, 20, 150, 25), "Player Health" + _playerHP);
                //5
                GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
                //6
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
            }
        }
    }
}


   
  
