using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodTriggerTwoStar : MonoBehaviour
{

    public float cdTime;
    public float countDown;
    public Vector3 spawnPoint;


    void Update()
    {
        countDown -= Time.deltaTime;



        if (countDown < 0)
        {
            int childNum;
            countDown = cdTime;
            childNum = Random.Range(0, 3);

            GameObject randomChild = transform.GetChild(childNum).gameObject;
            GameObject newChild = Instantiate(randomChild, spawnPoint, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            newChild.SetActive(true);
            newChild.GetComponent<Rigidbody>().velocity = new Vector3(0f, -2f, 0f);
        }
    }
}
