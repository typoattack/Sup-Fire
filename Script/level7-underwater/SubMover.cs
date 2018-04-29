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
    public AudioSource audioM;
    public GameObject bridge;
    public GameObject mast;

    void Start ()
    {
        rigid = this.GetComponent<Rigidbody>();
    }
	
	
	void Update ()
    {
        transform.position = new Vector3(-7f + Mathf.PingPong(Time.time, 14f), transform.position.y, transform.position.z);
        if(torpedohitcount <= 5)
        {
            bridge.GetComponent<Renderer>().material.color = Color.green;
            mast.GetComponent<Renderer>().material.color = Color.green;
        }
        if (torpedohitcount > 5 && torpedohitcount <= 10)
        {
            bridge.GetComponent<Renderer>().material.color = Color.yellow;
            mast.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (torpedohitcount > 10 && torpedohitcount < 15)
        {
            bridge.GetComponent<Renderer>().material.color = Color.red;
            mast.GetComponent<Renderer>().material.color = Color.red;
        }
        if (torpedohitcount >= 15)
        {
            torpedohitcount = 0;
            MissileMove newMissileleft = Instantiate(leftTorpedo, leftTorpedoSpawn.position, leftTorpedoSpawn.rotation) as MissileMove;
            newMissileleft.gameObject.SetActive(true);
            MissileMove newMissileright = Instantiate(rightTorpedo, rightTorpedoSpawn.position, rightTorpedoSpawn.rotation) as MissileMove;
            newMissileright.gameObject.SetActive(true);
            audioM.pitch = Random.Range(0.8f, 1.2f);
            audioM.Play();
        }
	}
}
