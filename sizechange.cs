using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizechange : MonoBehaviour {
    public float sizeparameter;
    private Vector3 size;
    public bool flag;
    public int objectnum;//0:player 1:bullet 2:missile
    public float cd;
    private float temp;
	// Use this for initialization
	void Start () {
        sizeparameter = 1;
        size = transform.localScale;
        flag = true;
        temp = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - temp >= cd)
        {
            flag = true;
        }
        if (sizeparameter > 1&& sizeparameter < 4&&flag&&objectnum==0) {

            transform.position = new Vector3(transform.position.x, -3.2f,transform.position.z);

        }
 
        else if (sizeparameter != 1 && objectnum == 1)
        {
            Animator a = gameObject.GetComponent<Animator>();
            a.enabled = false;


        }

        transform.localScale = new Vector3(size.x* sizeparameter, size.y * sizeparameter, size.z * sizeparameter);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "large"&&flag)
        {

            sizeparameter *= 2f;
            if (sizeparameter >= 2f)
                sizeparameter = 2f;
            temp = Time.time;
            flag = false;
        }
        else if (other.tag == "small"&&flag)
        {

            sizeparameter = sizeparameter*0.5f;
           if( sizeparameter <= 0.5f)
                sizeparameter=0.5f;
            temp = Time.time;
            flag = false;
        }
    }


}
