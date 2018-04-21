using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoFire : MonoBehaviour {

    public bulletMove bullet;
    public float bulletSpeed;

    void Start () {
        InvokeRepeating("Volcano", 5.0f, 10.0f);
    }
	
	void Volcano ()
    {
        bulletMove newBullet1 = Instantiate(bullet, transform.position, transform.rotation) as bulletMove;
        bulletMove newBullet2 = Instantiate(bullet, transform.position, transform.rotation) as bulletMove;
        bulletMove newBullet3 = Instantiate(bullet, transform.position, transform.rotation) as bulletMove;
        bulletMove newBullet4 = Instantiate(bullet, transform.position, transform.rotation) as bulletMove;
        bulletMove newBullet5 = Instantiate(bullet, transform.position, transform.rotation) as bulletMove;
        bulletMove newBullet6 = Instantiate(bullet, transform.position, transform.rotation) as bulletMove;


        newBullet1.gameObject.SetActive(true);
        newBullet1.transform.Translate(new Vector3(0f, 0f, 0f));
        newBullet1.transform.Rotate(new Vector3(0f, 0f, Random.Range(1f, 20f)));
        newBullet1.bulletSpeed = bulletSpeed;

        newBullet2.gameObject.SetActive(true);
        newBullet2.transform.Translate(new Vector3(0f, 0f, 0f));
        newBullet2.transform.Rotate(new Vector3(0f, 0f, Random.Range(1f, 20f)));
        newBullet2.bulletSpeed = bulletSpeed;

        newBullet3.gameObject.SetActive(true);
        newBullet3.transform.Translate(new Vector3(0f, 0f, 0f));
        newBullet3.transform.Rotate(new Vector3(0f, 0f, Random.Range(1f, 20f)));
        newBullet3.bulletSpeed = bulletSpeed;

        newBullet4.gameObject.SetActive(true);
        newBullet4.transform.Translate(new Vector3(0f, 0f, 0f));
        newBullet4.transform.Rotate(new Vector3(0f, 0f, Random.Range(-20f, -1f)));
        newBullet4.bulletSpeed = bulletSpeed;

        newBullet5.gameObject.SetActive(true);
        newBullet5.transform.Translate(new Vector3(0f, 0f, 0f));
        newBullet5.transform.Rotate(new Vector3(0f, 0f, Random.Range(-20f, -1f)));
        newBullet5.bulletSpeed = bulletSpeed;

        newBullet6.gameObject.SetActive(true);
        newBullet6.transform.Translate(new Vector3(0f, 0f, 0f));
        newBullet6.transform.Rotate(new Vector3(0f, 0f, Random.Range(-20f, -1f)));
        newBullet6.bulletSpeed = bulletSpeed;
    }
}
