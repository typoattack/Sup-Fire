using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM_XY : MonoBehaviour
{

    private Vector3 velocity;
    private Vector3 p;
    private int hit;//0 nothit;1 up;2 down
    public GameObject target;
    private float temp;
    public float BulletSpeed;
    public float Xmax;
    public float Xmin;
    public float Ymax;
    public float Ymin;
    public float upforceRange;
    public float upforceMagnitude;
    public GameObject cube;
    public bool _AIM;
    // Use this for initialization
    void Start()
    {
        hit = 0;
        Vector3 windy = new Vector3(0, upforceMagnitude, 0);
        float wind = WindController.wind;
        temp = Time.time;

        velocity = transform.rotation * Vector3.right * BulletSpeed * Time.deltaTime;

        p = transform.position;
        while (p.y > Ymin && p.y < Ymax && p.x < Xmax && p.x > Xmin)
        {
            if (p.x < upforceRange && p.x > -upforceRange)
            {
                if (wind > 0)
                    velocity += windy * Time.deltaTime * Time.deltaTime;
                else if (wind < 0)
                    velocity -= windy * Time.deltaTime * Time.deltaTime;

            }


            p += velocity;
            if (Mathf.Abs(p.x - target.transform.position.x) <= 1 && p.y - target.transform.position.y <= 2 && p.y - target.transform.position.y > -1)
                hit = 1;
            else if (Mathf.Abs(p.x - target.transform.position.x) <= 1 && p.y - target.transform.position.y >= -2 && p.y - target.transform.position.y <= -1)
                hit = 2;
                if (_AIM)
                Instantiate(cube, p, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target ?? false)
        {


            target.SendMessage("HitDetect", hit);
           
            target.SendMessage("GetBulletTime", Time.time);
            target.SendMessage("GetBulletSpeed", velocity);
            gameObject.GetComponent<AIM_XY>().enabled = false;


        }

    }
}

