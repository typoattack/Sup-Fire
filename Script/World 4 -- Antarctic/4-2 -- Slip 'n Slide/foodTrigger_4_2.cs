using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodTrigger_4_2 : MonoBehaviour {

    public float cdTime;
    public float countDown;
    private float topOrBottom;
    private GameObject newChild;

    private void Start()
    {
    }

    void Update()
    {
        topOrBottom = Random.Range(-1, 1);
        countDown -= Time.deltaTime;



        if (countDown < 0)
        {
            int childNum;
            countDown = cdTime;
            childNum = Random.Range(0, 4);

            GameObject randomChild = transform.GetChild(childNum).gameObject;
            //GameObject newChild = Instantiate(randomChild, new Vector3(0f, 0f, -0.5f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            if (topOrBottom >= 0f)
                newChild = Instantiate(randomChild, new Vector3(0f, 4.5f, 2.0f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            if (topOrBottom < 0f)
                newChild = Instantiate(randomChild, new Vector3(0f, -6.3f, 2.0f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            newChild.SetActive(true);
        }
    }
}
