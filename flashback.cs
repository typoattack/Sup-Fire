using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashback : MonoBehaviour {
    Queue time = new Queue();
    Queue ammo = new Queue();
    Queue hp = new Queue();
    public int accuracy;//number of deltime for flashback
    public int remainammo;
    public int remainhp;
    public float count;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
       if( Input.GetKey(KeyCode.Joystick1Button0))
            Debug.Log("J");

        if (Input.GetKey(KeyCode.A))
            Debug.Log("A");

        if (Input.GetKey(KeyCode.Space))
            Debug.Log("spcaea");
        /*8  time.Enqueue(transform.position);
          ammo.Enqueue(remainammo);
          hp.Enqueue(remainammo);
          if (time.Count >= accuracy)
          { time.Dequeue();
              ammo.Dequeue();
              hp.Dequeue();

          }

          */
    }
}
