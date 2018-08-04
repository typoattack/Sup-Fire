using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaController : MonoBehaviour {

    public GameObject SeaLR;
    public GameObject SeaRL;

    [HideInInspector] public static float dir;
    private int randomNumber;
    public float elapsedTime;

    void Start()
    {
        dir = 0;
        randomNumber = 0;
        //Invoke("WaveSea", 0.0f);
        SeaLR.gameObject.SetActive(true);
        SeaRL.gameObject.SetActive(true);
        InvokeRepeating("WaveSea", 0.0f, 4 * Mathf.PI);
    }

    private void Update()
    {
        elapsedTime = Time.time;
    }

    void WaveSea()
    {
        randomNumber = Random.Range(-4, 4);
        if (randomNumber < 0)
        {
            dir = -1;
            SeaLR.gameObject.SetActive(false);
            SeaRL.gameObject.SetActive(true);
        }
        else
        {
            dir = 1;
            SeaLR.gameObject.SetActive(true);
            SeaRL.gameObject.SetActive(false);
        }

    }
}
