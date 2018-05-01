using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {
    public float minX;
    public float maxX;
    public float velocity;
    public GameObject player;
    private bool hasPlayer;

    void SetPlayer(bool has) {
        hasPlayer = has;
        if (hasPlayer) player.SendMessage("SetPlatformVelocity", velocity);
        else player.SendMessage("SetPlatformVelocity", 0f);
    }
    
	void Start () {
        hasPlayer = false;
    }
	void FixedUpdate() {
        transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX - 0.1f, transform.position.y, transform.position.z);
            velocity = -velocity;
            if (hasPlayer) player.SendMessage("SetPlatformVelocity", velocity);
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX + 0.1f, transform.position.y, transform.position.z);
            velocity = -velocity;
            if (hasPlayer) player.SendMessage("SetPlatformVelocity", velocity);
        }
    }

    

}
