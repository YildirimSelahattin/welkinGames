using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject cross;
    public GameObject Bullet;
    private Vector3 mousePos;
    public float offSet;
    void Start()
    {
        
    }

    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            transform.position.z
        ));

        cross.transform.position = new Vector3(
            mousePos.x,
            mousePos.y,
            transform.position.z
        );

        if(Input.GetMouseButtonDown(0)) {
            shot();
        }
        
    }

    void FixedUpdate()
    {
        float rotateZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offSet);
    }

    private void shot() {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}