using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode0 : MonoBehaviour {
    public Material normal;
    public Material selected;
    public GameObject othermode;
    public GameObject SceneSwitch;
    public GameObject cube;
	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material = normal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 2f);
            Destroy(othermode, 2f);
            GetComponent<MeshRenderer>().material = selected;
            
            
        }
    }

}
