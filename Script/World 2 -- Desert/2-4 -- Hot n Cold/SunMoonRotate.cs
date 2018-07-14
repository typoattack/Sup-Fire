using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonRotate : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -Time.deltaTime * 12f);
	}
}
