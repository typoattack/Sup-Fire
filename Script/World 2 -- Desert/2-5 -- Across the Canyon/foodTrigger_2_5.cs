using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodTrigger_2_5 : MonoBehaviour {

    public float cdTime;
    public float countDown;
    private float wind;
    private GameObject newChild;

    private void Start()
    {
        wind = WindController.wind;
    }

    void Update()
    {
        wind = WindController.wind;
        countDown -= Time.deltaTime;



        if (countDown < 0)
        {
            int childNum;
            countDown = cdTime;
            childNum = Random.Range(0, 4);

            GameObject randomChild = transform.GetChild(childNum).gameObject;
            //GameObject newChild = Instantiate(randomChild, new Vector3(0f, 0f, -0.5f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            if (wind > 0f)
                newChild = Instantiate(randomChild, new Vector3(0f, -3.6f, -0.56f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            if (wind < 0f)
                newChild = Instantiate(randomChild, new Vector3(0f, 2.75f, -0.56f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            if (wind == 0f)
                newChild = Instantiate(randomChild, new Vector3(0f, 0.0f, -0.56f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            newChild.SetActive(true);
        }
    }
}
