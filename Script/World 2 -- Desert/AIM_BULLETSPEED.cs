using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM_BULLETSPEED : MonoBehaviour {

    private Vector3 velocity;
    private Vector3 p;
    public GameObject target;
    private float temp;
 
    private float BulletSpeed;
    public float bulletSpeedHot;
    public float bulletSpeedCold;
    public float Xmax;
    public float Xmin;
    public float Ymax;
    public float Ymin;
    public int BulletSelection;//0:normal bullet;1: lava
    private float wind;
    public GameObject t;
    public bool AIM;
    void Start()
    {

        wind = DayNightController.wind;
        if (wind > 0) BulletSpeed = bulletSpeedHot;
        if (wind < 0) BulletSpeed = bulletSpeedCold;
        if (wind == 0) BulletSpeed = 8.8f;
        temp = Time.time;
        velocity = transform.rotation * Vector3.right * BulletSpeed * Time.deltaTime;
        p = transform.position;
        while (p.y > Ymin && p.y < Ymax && p.x < Xmax && p.x > Xmin)
        {
            velocity += Physics.gravity * Time.deltaTime * Time.deltaTime;
            p += velocity;
            if (AIM)
            {
                Instantiate(t, p, Quaternion.identity);
            }
        }


    }

    private void Update()
    {
        if (target)
        {
            if (Time.time - temp >= 1)
            {
                if (BulletSelection == 0)
                {
                    target.SendMessage("GetBulletPos", p);
                    target.SendMessage("GetBulletTime", Time.time);
                    gameObject.GetComponent<AIM_BULLETSPEED>().enabled = false;
                }
                else if (BulletSelection == 1)
                {
                    target.SendMessage("GetLavalPos", p);
                    target.SendMessage("GetLavalTime", Time.time);
                    gameObject.GetComponent<AIM_BULLETSPEED>().enabled = false;

                }
            }
        }

    }
}


