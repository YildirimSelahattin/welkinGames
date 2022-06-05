using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    bool gameState;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameState == true)
            {
                GameReturn();
            }
            else if(gameState == false)
            {
                GamePause();
            } 
        }
    }
    public void GamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameState = true;
    }

    public void GameReturn()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameState = false;
    }
}
