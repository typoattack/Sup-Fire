using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestory : MonoBehaviour {
    public GameObject holder;
    public int player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall"||other.tag=="icicle")
            holder.SendMessage("PlayerMiss",player);

    }


}
