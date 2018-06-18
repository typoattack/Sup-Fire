using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIGHTCONTROL : MonoBehaviour {
    Vector3 poson;
    Vector3 posoff;
    public bool sw;
	// Use this for initialization
	void Start () {
        poson = transform.position;
        posoff=transform.position+= new Vector3(0, 0, -6.74f);
        transform.position = poson;
        sw = false;
    }

    void lightson()
    {

        transform.position = poson;
    }
    void lightsoff()
    {
        transform.position = posoff;

    }
    void swtrigger() {

        if (sw == false)
        {
            sw = true;
            lightsoff();
        }
        else
        {

            sw = false;
            lightson();

        }

    }
}
