using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM_REALTIME : MonoBehaviour {
    
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
                               // Use this for initialization
    void Start () {
        temp = Time.time;
      
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time - temp >= 1)
        {
            velocity = transform.rotation * Vector3.right * BulletSpeed * Time.deltaTime;
            p = transform.position;
            while (p.y > Ymin && p.y < Ymax && p.x < Xmax && p.x > Xmin)
            {
                velocity += Physics.gravity * Time.deltaTime * Time.deltaTime;
                p += velocity;

            }
            if (BulletSelection == 0)
            {
                target.SendMessage("GetBulletPos", p);
                target.SendMessage("GetBulletTime", Time.time);
                gameObject.GetComponent<AIM_REALTIME>().enabled = false;
            }
            else if (BulletSelection == 1)
            {
                target.SendMessage("GetLavalPos", p);
                target.SendMessage("GetLavalTime", Time.time);
                gameObject.GetComponent<AIM_REALTIME>().enabled = false;

            }

        }

		
	}
}
