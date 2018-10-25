using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud2move : MonoBehaviour {
    private float y;
    public float x0;
    public float x1;
    // Use this for initialization
    void Start () {
        y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-0.5f * Time.deltaTime, 0, 0);
        if (transform.position.x <= x0)
        {
            transform.position = new Vector3(-x1, y, -1.2f);
        }
	}
}
