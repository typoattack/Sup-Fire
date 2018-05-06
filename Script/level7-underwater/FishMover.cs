using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour {

    private Rigidbody rigid;
    public float SwimmingRange;
    public float speed;
    public bool isLeft = false;
    public float fishOffset;
    public float LastOffset = 0;
    void Start () {
        rigid = this.GetComponent<Rigidbody>();
        SwimmingRange = Random.Range(2f, 8f);
        speed = Random.Range(0.3f, 0.7f);
    }
	
	void FixedUpdate ()
    {
        fishOffset = Offset();
        transform.position = new Vector3(-SwimmingRange + fishOffset, transform.position.y, transform.position.z);

        if (fishOffset < LastOffset && !isLeft)
        {
            gameObject.transform.Rotate(180f, 0f, 0f);
            isLeft = !isLeft;
        }

        if (fishOffset > LastOffset && isLeft)
        {
            gameObject.transform.Rotate(180f, 0f, 0f);
            isLeft = !isLeft;
        }

        LastOffset = fishOffset;
    }

    private float Offset()
    {
        return Mathf.PingPong(Time.time * speed, SwimmingRange * 2);
    }
}
