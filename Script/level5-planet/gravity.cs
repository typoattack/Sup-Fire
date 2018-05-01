using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {

    public float Gforce;
    private Rigidbody itself;

    void Start () {
        itself=GetComponent<Rigidbody>();
       // itself.AddForce(10, 0, 0);
    }
	
	void Update () {
       Vector3 dir = Gforce * (new Vector3(0,0,0)-transform.position).normalized;
        itself.AddForce(dir);
    }
}
