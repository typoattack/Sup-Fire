using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIGHTCONTROL : MonoBehaviour
{
    Vector3 poson;
    Vector3 posoff;
    public float lasttime;//lights off time;
    public float buff_start_time;
    public float swcd;//every 10s allow switch once
    public GameObject lights;

    // Use this for initialization
    void Start()
    {
        poson = transform.position;
        posoff = transform.position += new Vector3(0, 0, -6.74f);
        transform.position = poson;

    }

    void lightson()
    {

        transform.position = poson;
    }
    void lightsoff()
    {
        transform.position = posoff;

    }


    private void FixedUpdate()
    {

        if (Time.time - buff_start_time >= lasttime)//lights on
        {
            lightson();
            
        }
        else
            lightsoff();

        if (Time.time - buff_start_time >= swcd)
            lights.SendMessage("setgreen");
        else
            lights.SendMessage("setred");
        


    }

    void setbuff(float buff_time)
    {
        if (Time.time - buff_start_time >= swcd)
            buff_start_time = buff_time;

    }

}