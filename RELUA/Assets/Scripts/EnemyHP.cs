using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public static float enemyHealth = 100;

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
