using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public Text CoinsTXT;
    public PlayerMovements playerScript;

    void Start()
    {
        CoinsTXT.text = "Coins:" + Score.totalScore.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (Score.totalScore >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            Score.totalScore -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
    private void Update()
    {

        CoinsTXT.text = "Tooth:" + Score.totalScore.ToString();

        if (shopItems[3,1] == 1)
        {
            Score.moveSpeed=6f;
            shopItems[3, 1] = 0;
        }
        if (shopItems[3, 2] == 1)
        {
            //playerScript.DamageUp();
            shopItems[3, 2] = 0;
        }
        if (shopItems[3, 3] == 1)
        {
            LivesController.health=100;
            shopItems[3, 3] = 0;
        }
        if (shopItems[3, 4] == 1)
        {
            //playerScript.BloodUp();
            shopItems[3, 4] = 0;
        }
    }
}
