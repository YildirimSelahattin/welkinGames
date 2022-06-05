using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{
    public GameObject shopMenu;
    bool gameState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (gameState == true)
            {
                GameReturn();
            }
            else if (gameState == false)
            {
                GamePause();
            }
        }
    }

    public void GamePause()
    {
        shopMenu.SetActive(true);
        Time.timeScale = 0;
        gameState = true;
    }

    public void GameReturn()
    {
        shopMenu.SetActive(false);
        Time.timeScale = 1;
        gameState = false;
    }
}
