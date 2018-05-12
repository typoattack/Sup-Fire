using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

    [HideInInspector] public static float wind;
    private int randomNumber;
    
	void Start () {
        wind = 0;
        randomNumber = 0;
        InvokeRepeating("BlowWind", 5.0f, 10.0f);
    }

    void BlowWind()
    {
        randomNumber = Random.Range(-4, 4);
        if (randomNumber < -1) wind = -0.25f;
        else if (randomNumber >= -1 && randomNumber <= -1) wind = 0f;
        else wind = 0.25f;

    }
}
