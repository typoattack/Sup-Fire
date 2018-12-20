using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDrop : MonoBehaviour {
    public IcicleMoveNew icicle0;
    public IcicleMoveNew icicle1;
    public IcicleMoveNew icicle2;
    private IcicleMoveNew[] icicle;
    public int cnt1;
    public int cnt2;
    public int dropNumber;
    public GameObject p1;
    public GameObject p2;
    // Use this for initialization
    void Start() {
        icicle =new IcicleMoveNew[]{icicle0,icicle1,icicle2};
	}

    // Update is called once per frame
    void Update() {
        if (cnt1 >= dropNumber)
        {  
            Vector3 randompos =new Vector3 (p1.gameObject.transform.position.x, 7.75f, -15.65f);
            int a = Random.Range(0, 3);
            IcicleMoveNew newIcicle = Instantiate(icicle[a],randompos,Quaternion.identity) as IcicleMoveNew;
            newIcicle.gameObject.SetActive(true);
            cnt1 = 0;
        }
        if (cnt2 >= dropNumber)
        {
            Vector3 randompos = new Vector3(p2.gameObject.transform.position.x, 7.75f, -15.65f);
            int a = Random.Range(0, 3);
            IcicleMoveNew newIcicle = Instantiate(icicle[a], randompos, Quaternion.identity) as IcicleMoveNew;
            newIcicle.gameObject.SetActive(true);
            cnt2 = 0;
        }

    }

    void PlayerMiss(int k)
    {   if (k == 1)
            cnt1++;
        else
            cnt2++;
  

    }

}
