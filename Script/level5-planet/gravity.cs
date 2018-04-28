using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
    private Rigidbody itself;
	// Use this for initialization
	void Start () {
        itself=GetComponent<Rigidbody>();
       // itself.AddForce(10, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
       Vector3 dir = 10*(new Vector3(0,0,0)-transform.position).normalized;
        itself.AddForce(dir);
    }
}
