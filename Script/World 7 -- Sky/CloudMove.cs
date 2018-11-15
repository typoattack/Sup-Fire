using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

    public float minX;
    public float maxX;
    public float velocity;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SendMessage("SetPlatformVelocity", velocity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SendMessage("SetPlatformVelocity", 0f);
        }
    }
}
