using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class AIM : MonoBehaviour
{

    private Vector3 velocity;
    private Vector3 p;
    public GameObject target;
    private float temp;
    public float BulletSpeed;
    public float Xmax;
    public float Xmin;
    public float Ymax;
    public float Ymin;
    public int BulletSelection;//0:normal bullet;1: lava
    public GameObject cube;
    public bool _AIM;
    void Start()
    {
        temp = Time.time;
        velocity = transform.rotation * Vector3.right * BulletSpeed * Time.deltaTime;
        p = transform.position;
        while (p.y > Ymin&&p.y<Ymax && p.x < Xmax && p.x > Xmin)
        {
            velocity += Physics.gravity * Time.deltaTime * Time.deltaTime;
            p += velocity;
            if (_AIM)
                Instantiate(cube, p, Quaternion.identity);
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
                    gameObject.GetComponent<AIM>().enabled = false;
                }
                else if (BulletSelection == 1)
                {
                    target.SendMessage("GetLavalPos", p);
                    target.SendMessage("GetLavalTime", Time.time);
                    gameObject.GetComponent<AIM>().enabled = false;

                }
            }
        }

    }
}


