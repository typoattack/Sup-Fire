using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
    public float minX;
    public float maxX;
    public float velocity;
    //public GameObject player;
    //private bool hasPlayer;

    void Start () {
        //hasPlayer = false;
     }
	
	void FixedUpdate() {
        transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z);
        //if (hasPlayer) player.SendMessage("SetPlatformVelocity", velocity);
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX - 0.1f, transform.position.y, transform.position.z);
            velocity = -velocity;
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX + 0.1f, transform.position.y, transform.position.z);
            velocity = -velocity;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other);
    //    hasPlayer = true;
    //    //if (other.tag != "Player") return;
    //    //other.transform.parent = gameObject.transform;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //if (other.tag != "Player") return;
    //    //other.transform.parent.parent = null;
    //    hasPlayer = false;
    //}

}
