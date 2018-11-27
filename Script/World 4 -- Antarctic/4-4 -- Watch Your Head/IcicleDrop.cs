using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDrop : MonoBehaviour {
    public IcicleMove icicle;
    public int cnt1;
    public int cnt2;
    public int dropNumber;
    // Use this for initialization
    void Start() {
        
	}

    // Update is called once per frame
    void Update() {
        if (cnt1 >= dropNumber)
        {  
            Vector3 randompos =new Vector3 (Random.Range(-12.4f, -1.7f), 7.75f, -1f);
            IcicleMove newIcicle = Instantiate(icicle,randompos,transform.rotation) as IcicleMove;
            newIcicle.gameObject.SetActive(true);
            cnt1 = 0;
        }
        if (cnt2 >= dropNumber)
        {
            Vector3 randompos = new Vector3(Random.Range(1.7f, 10f), 7.75f, -1f);
            IcicleMove newIcicle = Instantiate(icicle, randompos, transform.rotation) as IcicleMove;
            newIcicle.gameObject.SetActive(true);
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
