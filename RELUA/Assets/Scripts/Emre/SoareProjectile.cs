using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoareProjectile : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float bulletSpeed;
    private Transform _FireExit;//Fýrlatýlacak nesnenin çýkýþ pozisyonunu ayarlamak için oyunda bulunan gameobject
    private Transform enemyPos;
    Vector3 _exitPos;//Fýrlatýlacak nesnenin çýkýþ pozisyon deðerini tutan deðiþken
    public float betweenAttack;
    public float betweenMultiAttack;
    public bool allowAttack = true;
    public bool playerInRange = false;

    private void Start()
    {
        _FireExit = GameObject.FindGameObjectWithTag("FireExit").GetComponent<Transform>();
        enemyPos = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    private void Update()
    {
        _exitPos = _FireExit.position;
        Vector2 targetDir = new Vector2(enemyPos.position.x - _exitPos.x,
            enemyPos.position.y - _exitPos.y);
        if (playerInRange==true && allowAttack == true)
        {
            StartCoroutine(NextShoot(betweenMultiAttack,betweenAttack,targetDir));         
        }
    }
    private void Shoot(Vector2 exitPoint)
    {
        GameObject clone = Instantiate(bullet, _exitPos, transform.rotation) as GameObject;
        Rigidbody2D _rb = clone.GetComponent<Rigidbody2D>();
        //Bullet objesini fýrlatma
        _rb.AddRelativeForce(exitPoint * bulletSpeed, ForceMode2D.Impulse);
        //X Saniye sonra objeyi yok etme
        Destroy(clone, 5);
    }
    IEnumerator NextShoot(float timeMulti,float timeSingle, Vector2 targetDir)
    {
        allowAttack = false;
        Shoot(targetDir);
        yield return new WaitForSeconds(timeMulti);
        Shoot(targetDir);
        yield return new WaitForSeconds(timeMulti);
        Shoot(targetDir);
        yield return new WaitForSeconds(timeSingle);
        allowAttack = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player") playerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player") playerInRange = false;
    }
}
