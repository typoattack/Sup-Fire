using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicledestory : MonoBehaviour {
    private bool ifdestory;
    // Use this for initialization
    void Start () {
        ifdestory = false;
	}


    void setflag(bool a)
    {
        ifdestory = a;
        
    }

	// Update is called once per frame
	void Update () {
		
	}
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall"&&ifdestory==true)
            Destroy(gameObject);
    }




}
