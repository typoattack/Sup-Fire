using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour {

    public float angularVelocity;
    public bool clockwise;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.Rotate(0f, 0f, (clockwise ? -angularVelocity : angularVelocity) * Time.deltaTime);
	}
}
