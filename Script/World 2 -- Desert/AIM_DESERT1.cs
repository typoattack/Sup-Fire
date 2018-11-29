using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM_DESERT1 : MonoBehaviour {

    // Use this for initialization
    private Vector3 velocity;
    private Vector3 p;
    public GameObject target;
    private float temp;
    public float BulletSpeed;

    public float Xmax;
    public float Xmin;
    public float Ymax;
    public float Ymin;
    public int BulletSelection;
    public GameObject t;
    public bool AIM;

    // Use this for initialization
    void Start()
    {
        temp = Time.time;
        Vector3 wind = new Vector3(WindController.wind * 10, 0, 0);
        velocity = transform.rotation * Vector3.right * BulletSpeed * Time.deltaTime;
        p = transform.position;
        while (p.y > Ymin && p.y < Ymax && p.x < Xmax && p.x > Xmin)
        {
            velocity += Physics.gravity * Time.deltaTime * Time.deltaTime + wind * Time.deltaTime * Time.deltaTime;
            p += velocity;
            if (AIM)
            {
                Instantiate(t, p + new Vector3(0f, 0f, 0.1f), Quaternion.identity);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (Time.time - temp >= 1)
            {
                if (BulletSelection == 0)
                {
                    target.SendMessage("GetBulletPos", p);
                    target.SendMessage("GetBulletTime", Time.time);
                    gameObject.GetComponent<AIM_DESERT1>().enabled = false;
                }
                else if (BulletSelection == 1)
                {
                    target.SendMessage("GetLavalPos", p);
                    target.SendMessage("GetLavalTime", Time.time);
                    gameObject.GetComponent<AIM_DESERT1>().enabled = false;

                }
            }
        }




    }
}
