using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
    public Transform canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;


            }

        }
	}
}
