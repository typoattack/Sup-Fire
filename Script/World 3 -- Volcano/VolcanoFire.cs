using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class VolcanoFire : MonoBehaviour {

    public LavaMove Lava;
    public int NumOfLava;
    public float LavaSpeed;
    public float LavaAngle;
    public float fistLavaTime;
    public float lavaRepeatTime;

    public float shakeMagnitude;
    public float shakeRoughness;
    public float shakeFadein;
    public float shakeFadeout;

    public AudioSource eruption;

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

        CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadein, shakeFadeout);
        eruption.volume = 2f;
        eruption.Play();
    }
}
