using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMove : MonoBehaviour {

    public GameObject PortalOrange;
    public GameObject PortalBlue;

	void Update () {
        PortalOrange.transform.position = new Vector3(PortalOrange.transform.position.x, -Mathf.PingPong(Time.time, 2), PortalOrange.transform.position.z);
        PortalBlue.transform.position = new Vector3(PortalBlue.transform.position.x, -2.0f + Mathf.PingPong(Time.time, 2), PortalBlue.transform.position.z);

    }
}
