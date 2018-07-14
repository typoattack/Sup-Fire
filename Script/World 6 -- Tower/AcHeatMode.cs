using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcHeatMode : MonoBehaviour {
    public Queue<float> timetable= new Queue<float>();
    public Material Overheat;
    public Material normal;
    public Material nearloverheat;
    public int temperature;
    private float Overheadtime;
    public float punishTime;
	// Use this for initialization
	void Start () {
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
        Debug.Log(temperature);
        if (temperature >= 5)
        {
            transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = Overheat;
            gameObject.SendMessage("StopFire");
            if (Time.time - Overheadtime > punishTime)
            {
                temperature = 0;
                gameObject.SendMessage("ResetAmmo");
            }
        }
        else if (temperature >= 2&&temperature<5)
        {

            transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = nearloverheat;

        }
        else
        {
            transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().material = normal;

        }
    }


}
