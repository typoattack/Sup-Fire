using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour {
    public float cd;
    public float temp;
    private Vector3 place;
	// Use this for initialization
	void Start () {
        place = transform.position + new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {

        //if (other.gameObject.tag == "Bullet")
          //  other.gameObject.SendMessage("dir", true);
        if (Time.time - temp >= cd)
        {
            Debug.Log("1");
            int childNum;

            childNum = Random.Range(0, 4);

            GameObject randomChild = transform.GetChild(childNum).gameObject;
            GameObject newChild = Instantiate(randomChild, place, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            newChild.SetActive(true);

            temp = Time.time;
        }
    }

  

}
