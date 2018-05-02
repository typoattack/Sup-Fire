using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMover : MonoBehaviour {

    private Rigidbody rigid;
    public static int torpedohitcountleft = 0;
    public static int torpedohitcountright = 0;
    public Transform leftTorpedoSpawn;
    public Transform rightTorpedoSpawn;
    public MissileMove leftTorpedo;
    public MissileMove rightTorpedo;
    public AudioSource audioM;
    public GameObject stern;
    public GameObject bow;

    void Start ()
    {
        rigid = this.GetComponent<Rigidbody>();
    }
	
	
	void Update ()
    {
        transform.position = new Vector3(-7f + Mathf.PingPong(Time.time, 14f), transform.position.y, transform.position.z);
        if(torpedohitcountleft < 5)
        {
            stern.GetComponent<Renderer>().material.color = Color.green;
        }
        if (torpedohitcountleft >= 5 && torpedohitcountleft < 7)
        {
            stern.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (torpedohitcountleft >=7 && torpedohitcountleft < 10)
        {
            stern.GetComponent<Renderer>().material.color = Color.red;
        }
        if (torpedohitcountleft >= 10)
        {
            torpedohitcountleft = 0;
            MissileMove newMissileleft = Instantiate(leftTorpedo, leftTorpedoSpawn.position, leftTorpedoSpawn.rotation) as MissileMove;
            newMissileleft.gameObject.SetActive(true);
            //MissileMove newMissileright = Instantiate(rightTorpedo, rightTorpedoSpawn.position, rightTorpedoSpawn.rotation) as MissileMove;
            //newMissileright.gameObject.SetActive(true);
            audioM.pitch = Random.Range(0.8f, 1.2f);
            audioM.Play();
        }
        if (torpedohitcountright <= 5)
        {
            bow.GetComponent<Renderer>().material.color = Color.green;
        }
        if (torpedohitcountright >= 5 && torpedohitcountright < 7)
        {
            bow.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (torpedohitcountright >= 7 && torpedohitcountright < 10)
        {
            bow.GetComponent<Renderer>().material.color = Color.red;
        }
        if (torpedohitcountright >= 10)
        {
            torpedohitcountright = 0;
            //MissileMove newMissileleft = Instantiate(leftTorpedo, leftTorpedoSpawn.position, leftTorpedoSpawn.rotation) as MissileMove;
            //newMissileleft.gameObject.SetActive(true);
            MissileMove newMissileright = Instantiate(rightTorpedo, rightTorpedoSpawn.position, rightTorpedoSpawn.rotation) as MissileMove;
            newMissileright.gameObject.SetActive(true);
            audioM.pitch = Random.Range(0.8f, 1.2f);
            audioM.Play();
        }
    }
}
