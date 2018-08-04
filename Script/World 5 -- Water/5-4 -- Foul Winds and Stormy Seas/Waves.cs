using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    public float waveNumber;
    private int activated;
    private float t;
    private float currentTime;
    private float direction;
    private float checkDir;
    
	void Start ()
    {
        activated = 0;
        t = 0;
        currentTime = Time.time;
        direction = SeaController.dir;
	}
	
	void Update ()
    {
        checkDir = SeaController.dir;
        makeWaves();
        if (Time.time >= currentTime + waveNumber * 0.05 && t == 0)
        {
            activated = 1;
            t = Time.time;
        }

        //if (direction != checkDir) gameObject.SetActive(false);
        
	}

    void makeWaves()
    {
        if (activated == 1)
        {
            transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time - t) / 2f) * 4f) - 8f, transform.position.z);
        }
    }
}
