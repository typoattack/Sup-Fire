using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour {

    public float RocketSpeed;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigid.transform.Translate(0f, RocketSpeed, 0f);

        if (gameObject.transform.position.y < -7)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 7f, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.y > 7.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -6.5f, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x < -12)
        {
            gameObject.transform.position = new Vector3(11.5f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x > 12f)
        {
            gameObject.transform.position = new Vector3(-11.5f, gameObject.transform.position.y, gameObject.transform.position.z);

        }
    }
}
