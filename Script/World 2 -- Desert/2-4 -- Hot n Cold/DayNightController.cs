using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {

    public GameObject WindLR;
    public GameObject WindRL;
    public GameObject DayPlane;
    public GameObject Sun;
    public GameObject NightPlane;
    public GameObject Moon;

    [HideInInspector] public static float wind;
    
	void Start () {
        wind = 0;
        InvokeRepeating("Day", 0.0f, 30.0f);
        InvokeRepeating("Night", 15.0f, 30.0f);
    }

    void Day()
    {
        
        wind = 0.25f;
        WindLR.gameObject.SetActive(true);
        WindRL.gameObject.SetActive(false);
        DayPlane.gameObject.SetActive(true);
        //Sun.gameObject.SetActive(true);
        //Moon.gameObject.SetActive(false);
        NightPlane.gameObject.SetActive(false);
        

    }

    void Night()
    {
        wind = -0.25f;
        WindRL.gameObject.SetActive(true);
        WindLR.gameObject.SetActive(false);
        DayPlane.gameObject.SetActive(false);
        //Sun.gameObject.SetActive(false);
        //Moon.gameObject.SetActive(true);
        NightPlane.gameObject.SetActive(true);
    }
}
