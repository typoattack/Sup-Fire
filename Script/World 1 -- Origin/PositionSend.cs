using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSend : MonoBehaviour {
    public GameObject target;
    private float temp;
    public int HostSelection;//0:player;1:ICE
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            if (HostSelection == 0)
            {
                if (Time.time - temp >= 0.5)
                {
                    target.SendMessage("GetTargetPos", transform.position);
                    temp = Time.time;
                }
            }
            else if (HostSelection == 1)
            {
                if (Time.time - temp >= 0.5)
                {
                    target.SendMessage("GetIcePos", transform.position);
                    temp = Time.time;
                }
            }
        }
    }
}
