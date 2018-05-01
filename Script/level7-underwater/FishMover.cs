using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour {

    private Rigidbody rigid;
    private float randomNumber;
    private float speed;

    // Use this for initialization
    void Start () {
        rigid = this.GetComponent<Rigidbody>();
        randomNumber = Random.Range(3f, 7f);
        speed = Random.Range(0.5f, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(-randomNumber + Mathf.PingPong(Time.time * speed, randomNumber * 2), transform.position.y, transform.position.z);
    }
}
