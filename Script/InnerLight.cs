using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLight : MonoBehaviour {
    public float Speed;

    void Heavy()
    {

    }

    void Light()
    {

    }

	void Start () {
		
	}
	
	void FixedUpdate () {
        for (int i = 0; i < gameObject.transform.childCount; i++)


           transform.GetChild(i).transform.localPosition += transform.GetChild(i).transform.localPosition * Speed;
	}
}
