using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcHeatMode : MonoBehaviour
{
    private float time1;
    private float time2;

    public Material temperature0;
    public Material temperature1;
    public Material temperature2;
    public Material temperature3;
    public Material temperature4;
    
    public int temperature;
    private float Overheadtime;
    public float punishTime;
    // Use this for initialization
    void Start()
    {
        Reset();
        temperature = 0;
    }


    void Add(float FireTime)
    {
        time2 = FireTime;
       
       // timetable.TrimExcess();

        if (time2-time1 <= 2f && (time1 != 0))
        {

            temperature += 1;
            Overheadtime = Time.time;
          
        }
        else
        {
            Overheadtime = Time.time;
        }
        if (temperature <= 0)
            temperature = 0;
        time1 = time2;
    }

    void Reset()
    {
        
        temperature = 0;
        time1 = 0;time2 = 0;
    }

    private void FixedUpdate()
    {
        if (Time.time - Overheadtime >= 2f)
            temperature = 0;

        switch (temperature)
        {
             
            case (4):
                transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = temperature4;
                gameObject.SendMessage("StopFire");
                transform.GetChild(1).GetChild(1).GetChild(2).gameObject.SetActive(true);
                if (Time.time - Overheadtime > punishTime)
                {
                    temperature = 0;
                    gameObject.SendMessage("ResetAmmo");
                }
                break;
            case (3):
                transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = temperature3;
        
                break;
            case (2):
                transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = temperature2;
    
                break;
            case (1):
                transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = temperature1;

                break;
            case (0):
                transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = temperature0;
 
                transform.GetChild(1).GetChild(1).GetChild(2).gameObject.SetActive(false);
                gameObject.SendMessage("ResetAmmo");
                break;

        }

    }
}
