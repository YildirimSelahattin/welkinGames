using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{

    public Text Tcounter;
    private int tooth = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            Collect(collision.GetComponent<Collectibles>());
        }
        void Collect(Collectibles collectible)
        {
            if (collectible.Collect())
            {
                if(collectible is HealthCollectible)
                {

                }
                else if(collectible is ToothCollectible)
                {
                    tooth++;
                }
                UpdateGUI();    
            }

        }
    }
    private void UpdateGUI()
    {
        Tcounter.text = tooth.ToString();
    }
}
