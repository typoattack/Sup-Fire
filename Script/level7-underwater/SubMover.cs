using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMover : MonoBehaviour {

    private Rigidbody rigid;
    public static int torpedohitcount = 0;
    public Transform leftTorpedoSpawn;
    public Transform rightTorpedoSpawn;
    public MissileMove leftTorpedo;
    public MissileMove rightTorpedo;

    
    void Start ()
    {
        rigid = this.GetComponent<Rigidbody>();
    }
	
	
	void Update ()
    {
        transform.position = new Vector3(-7f + Mathf.PingPong(Time.time, 14f), transform.position.y, transform.position.z);
        if(torpedohitcount >= 15)
        {
            torpedohitcount = 0;
            MissileMove newMissileleft = Instantiate(leftTorpedo, leftTorpedoSpawn.position, leftTorpedoSpawn.rotation) as MissileMove;
            newMissileleft.gameObject.SetActive(true);
            MissileMove newMissileright = Instantiate(rightTorpedo, rightTorpedoSpawn.position, rightTorpedoSpawn.rotation) as MissileMove;
            newMissileright.gameObject.SetActive(true);
        }
	}
}
