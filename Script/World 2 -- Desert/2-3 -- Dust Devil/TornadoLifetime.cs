using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoLifetime : MonoBehaviour {

    private float spawntime;

    // Use this for initialization
    void Start () {
        spawntime = 10f;
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, spawntime);
    }
}
