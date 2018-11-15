using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudVerticalMove : MonoBehaviour {

    public float velocity;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = new Vector3(0f, velocity, 0f);
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.y < -7)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 7f, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.y > 7.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -6.5f, gameObject.transform.position.z);

        }
    }


}
