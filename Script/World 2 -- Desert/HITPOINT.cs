using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HITPOINT : MonoBehaviour {
    private float t;
    public GameObject belongTo;
	
    // Use this for initialization
	void Start () {
        t = Time.time;
	}
	
    // Update is called once per frame
	void Update () {
        if (!(belongTo))
        {
            Destroy(gameObject);
        }
            
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == belongTo)
        {
            Destroy(gameObject);
        }
    }
}
