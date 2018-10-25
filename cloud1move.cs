using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud1move : MonoBehaviour {
    public float ylimit;
    private float init;
    private bool direction;
	// Use this for initialization
	void Start () {
        init = transform.position.y;
        direction = true;

	}

    // Update is called once per frame
    void Update() {
        if (direction)
        {
            if (transform.position.y >= ylimit)
                transform.position += new Vector3(0, 0.1f*-Time.deltaTime, 0);
            else
                direction = false;
        }
        else { 
             if (transform.position.y <= init)
                transform.position += new Vector3(0, 0.1f * Time.deltaTime, 0);
            else
                direction = true;
        }
        
    }
}
