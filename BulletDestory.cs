using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestory : MonoBehaviour {
    public GameObject holder;
    private int player;
	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<bulletMove>().comeFrom.name == "Player1")
            player = 0;
        else if (gameObject.GetComponent<bulletMove>().comeFrom.name == "Player2")
            player = 1;
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
