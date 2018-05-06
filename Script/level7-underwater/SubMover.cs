using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMover : MonoBehaviour {

    private Rigidbody rigid;
    public static int torpedohitcountleft = 0;
    public static int torpedohitcountright = 0;
    public Transform leftTorpedoSpawn;
    public Transform rightTorpedoSpawn;
    public MissileMoveUnderwater leftTorpedo;
    public MissileMoveUnderwater rightTorpedo;
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
        if(torpedohitcountleft < 2)
        {
            stern.GetComponent<Renderer>().material.color = Color.green;
        }
        if (torpedohitcountleft >= 2 && torpedohitcountleft < 4)
        {
            stern.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (torpedohitcountleft >=4 && torpedohitcountleft < 5)
        {
            stern.GetComponent<Renderer>().material.color = Color.red;
        }
        if (torpedohitcountleft >= 5)
        {
            torpedohitcountleft = 0;
            MissileMoveUnderwater newMissileleft = Instantiate(leftTorpedo, leftTorpedoSpawn.position, leftTorpedoSpawn.rotation) as MissileMoveUnderwater;
            newMissileleft.gameObject.SetActive(true);
            audioM.pitch = Random.Range(0.8f, 1.2f);
            audioM.Play();
        }
        if (torpedohitcountright <= 2)
        {
            bow.GetComponent<Renderer>().material.color = Color.green;
        }
        if (torpedohitcountright >= 2 && torpedohitcountright < 4)
        {
            bow.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (torpedohitcountright >= 4 && torpedohitcountright < 5)
        {
            bow.GetComponent<Renderer>().material.color = Color.red;
        }
        if (torpedohitcountright >= 5)
        {
            torpedohitcountright = 0;
            MissileMoveUnderwater newMissileright = Instantiate(rightTorpedo, rightTorpedoSpawn.position, rightTorpedoSpawn.rotation) as MissileMoveUnderwater;
            newMissileright.gameObject.SetActive(true);
            audioM.pitch = Random.Range(0.8f, 1.2f);
            audioM.Play();
        }
    }
}
