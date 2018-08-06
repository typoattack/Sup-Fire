using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerDrop : MonoBehaviour {
    public GameObject container;
    public int cnt1;
    public int cnt2;
    // Use this for initialization
    void Start() {
        
	}

    // Update is called once per frame
    void Update() {
        if (cnt1 >= 5)
        {  
            Vector3 randompos =new Vector3 (Random.Range(-7, 0),2.4f,-0.5f);
            Instantiate(container,randompos, Quaternion.identity);
            cnt1 = 0;
        }
        if (cnt2 >= 5)
        {
            Vector3 randompos = new Vector3(Random.Range(0, 7), 2.4f, -0.5f);
            Instantiate(container, randompos, Quaternion.identity);
            cnt2 = 0;
        }

    }

    void PlayerMiss(int k)
    {if (k == 0)
            cnt1++;
        else
            cnt2++; 

    }

}
