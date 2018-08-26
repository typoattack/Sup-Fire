using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icebergFloating : MonoBehaviour {

    public float range;
    public float MovingSpeed;
    bool direction;//true = left; false = right
    Rigidbody rigid;
    float originX;

    private void Start()
    {
        direction = Random.Range(0f, 1f) < 0.5 ? true : false;
        rigid = gameObject.GetComponent<Rigidbody>();
        originX = this.transform.position.x;
    }

    void FixedUpdate () {
		if (direction)
        {
            rigid.transform.Translate(-MovingSpeed * 0.01f, 0f, 0f);
            if (gameObject.transform.position.x - originX <= -range)
            {
                direction = !direction;
            }
        }
        else
        {
            rigid.transform.Translate(MovingSpeed * 0.01f, 0f, 0f);
            if (gameObject.transform.position.x - originX >= range)
            {
                direction = !direction;
            }
        }
	}
}
