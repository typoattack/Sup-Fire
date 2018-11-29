using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_move : MonoBehaviour {
    public float limit;
    public float cd;
    public float lasttime;
    private float temp;
    public Material large;
    public Material small;
    private Material[] color;
    private bool direction;
    private string[] taglist; 
	// Use this for initialization
	void Start () {
        direction = true;
        color=new Material[]{ large, small };
        taglist = new string[] { "large", "small" };
        temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction)
        {
            transform.position += new Vector3(0.05f, 0, 0);
            if (transform.position.x > limit)
                direction = false;

        }
        else
        {
            transform.position += new Vector3(-0.05f, 0, 0);
            if (transform.position.x <- limit)
                direction = true;
        }
        if (Time.time - temp >= cd)
        { int a = Random.Range(0, 2);

            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent <MeshRenderer>().material= color[a];
            transform.GetChild(0).gameObject.tag = taglist[a];
            temp = Time.time;

        }
        if (Time.time - temp >= lasttime)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        

    }
}
