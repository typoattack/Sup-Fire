using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveMid : MonoBehaviour {
    public float minY;
    public float maxY;
    public float velocity;

	
	void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + velocity * Time.deltaTime, transform.position.z);
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY - 0.1f, transform.position.z);
            velocity = -velocity;
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY + 0.1f, transform.position.z);
            velocity = -velocity;
        }
    }

}
