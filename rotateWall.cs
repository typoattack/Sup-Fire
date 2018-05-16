using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWall : MonoBehaviour {

    public float ang;
    public float angSpeed;
	void Start () {
        ang = 90;
	}
	
	// Update is called once per frame
	void Update () {
        ang += angSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, ang);
	}
}
