using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBullet : MonoBehaviour {
    private float entertime;
    private float exittime;
    public GameObject bullet;
    private Vector3 speed;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (entertime != 0 && exittime != 0 && exittime - entertime >= 0.1)
        {
            player.SendMessage("SetAmmo",1);
            GameObject a=Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        entertime = Time.time;
    }

    private void OnTriggerExit(Collider other)
    {
        exittime = Time.time;
    }


}
