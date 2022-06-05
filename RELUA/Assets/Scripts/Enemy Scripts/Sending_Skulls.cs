using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sending_Skulls : MonoBehaviour
{
    public GameObject[] skulls;
    private int rand;
    
    
    
    void Start()
    {
        
        InvokeRepeating("Send", 2f, 10f);
        
    }

   
    void Update()
    {
        
    }

    void Send()
    {
        rand = Random.Range(0, skulls.Length);
        Instantiate(skulls[rand], transform.position, transform.rotation);
    }
}
