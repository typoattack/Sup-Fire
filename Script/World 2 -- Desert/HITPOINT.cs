using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HITPOINT : MonoBehaviour {
    private float t;
	// Use this for initialization
	void Start () {
        t = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - t > 1)
            Destroy(gameObject);
	}
}
