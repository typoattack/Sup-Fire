using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatewithflashback : MonoBehaviour {

    public float ang;
    public float angSpeed;
    private float flashbacktime;
    void Start()
    {
        flashbacktime = 0f;
        ang = 90;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= flashbacktime + 0.2f||flashbacktime==0)
        {
            ang += angSpeed * Time.deltaTime * (1 / Time.timeScale); ;
            transform.rotation = Quaternion.Euler(0, 0, ang);
        }
        else
        {
            ang -=3* angSpeed * Time.deltaTime*(1/Time.timeScale);
            transform.rotation = Quaternion.Euler(0, 0, ang);
        }
    }
    void setflag(float t)
    {
        flashbacktime = t;
    }
}
