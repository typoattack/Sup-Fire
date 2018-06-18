using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloeMove : MonoBehaviour {

    public float velocity;
    public float maxVelocity;
    public float rebound; //velocity after bounce is rebound percent of velocity before
    public float minX;
    public float maxX;
    private Rigidbody rigid;
    public GameObject player;
    public bool playerExist;

    public void UpdateVelocity(float delta) {
        velocity += delta;
        if (velocity > maxVelocity) velocity = maxVelocity;
        else if (velocity < -maxVelocity) velocity = -maxVelocity;
    }

    void PlayerDie() {
        playerExist = false;
    }
    void Start() {
        rigid = this.GetComponent<Rigidbody>();
        playerExist = true;
    }

    void Update() {
        rigid.velocity = new Vector3(velocity, rigid.velocity.y, 0f);
        if (rigid.position.x > maxX)
        {
            rigid.position = new Vector3(maxX-0.1f, rigid.position.y, rigid.position.z);
            velocity = -velocity * rebound;
        }
        else if (rigid.position.x < minX) {
            rigid.position = new Vector3(minX+0.1f, rigid.position.y, rigid.position.z);
            velocity = -velocity * rebound;
        }
        if (playerExist) player.SendMessage("GetFloeVelocity", velocity);
    }
}
