using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcHeatMode : MonoBehaviour
{
    public Queue<float> timetable = new Queue<float>();

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
        ResetQueue();
        temperature = 0;
    }


    void Add(float FireTime)
    {

        float firstfire = timetable.Dequeue();
        timetable.Enqueue(FireTime);
        timetable.TrimExcess();
        if (Mathf.Abs(firstfire - FireTime) <= 1f && (firstfire != 0))
        {

            temperature += 1;
            Overheadtime = Time.time;
        }
        else
            temperature -= 1;
        if (temperature <= 0)
            temperature = 0;

    }

    void ResetQueue()
    {
        
        temperature = 0;
        timetable.Clear();
        timetable.Enqueue(0);
        timetable.Enqueue(0);
    }

    private void FixedUpdate()
    {
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
