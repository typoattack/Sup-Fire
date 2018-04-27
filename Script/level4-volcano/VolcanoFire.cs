using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoFire : MonoBehaviour {

    public LavaMove Lava;
    public int NumOfLava;
    public float LavaSpeed;
    public float LavaAngle;
    public float fistLavaTime;
    public float lavaRepeatTime;

    void Start () {
        InvokeRepeating("Volcano", fistLavaTime, lavaRepeatTime);
    }
	
	void Volcano ()
    {
        List<LavaMove> LavaList = new List<LavaMove>(); 

        for(int i = 0; i < NumOfLava; i++)
        {
            LavaMove newLava = Instantiate(Lava, transform.position, transform.rotation) as LavaMove;
            LavaList.Add(newLava);
        }

        for (int i = 0; i < NumOfLava; i++)
        {
            LavaList[i].gameObject.SetActive(true);
            LavaList[i].transform.Translate(new Vector3(0f, 0f, 0f));
            LavaList[i].transform.Rotate(new Vector3(0f, 0f, Random.Range(-LavaAngle, LavaAngle)));
            LavaList[i].LavaSpeed = LavaSpeed;
        }
    }
}
