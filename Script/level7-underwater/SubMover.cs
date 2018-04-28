using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMover : MonoBehaviour {

    private Rigidbody rigid;

    
    void Start ()
    {
        rigid = this.GetComponent<Rigidbody>();
    }
	
	
	void Update ()
    {
        transform.position = new Vector3(-7f + Mathf.PingPong(Time.time, 14f), transform.position.y, transform.position.z);
	}
}
