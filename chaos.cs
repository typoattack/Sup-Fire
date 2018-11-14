using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaos : MonoBehaviour {

    public GameObject k;
    public float distance;
    private float temptime;
    public float speed;
	// Use this for initialization
	void Start () {
        temptime = 0;
   
	}


	
	// Update is called once per frame
	void Update () {

            temptime += speed * Time.deltaTime;
              gameObject.SetActive(true);
              transform.position = new Vector3(distance * Mathf.Cos(temptime), 0.8f, -1f)+k.transform.position;

	}
}
