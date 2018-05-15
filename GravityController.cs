using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    public float ChangeTime;
    public float MinGravity;
    public float MaxGravity;
    public Material MinMaterial;
    public Material MaxMaterial;
    public bulletMove_L9 b1;
    public bulletMove_L9 b2;
    public AudioSource GravityChange;

    public float CountDown;
    bool isMin = true;
    bool notPlayed = true;

    void Start () {
        CountDown = ChangeTime;
    }
	
	void FixedUpdate () {
        CountDown -= Time.deltaTime;

        if (CountDown <= 0)
        {
            CountDown = ChangeTime;
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = isMin ? MaxMaterial : MinMaterial;
            }

            if (isMin)
            {
                for(int i = 0; i< bullets.Length; i++)
                {
                    bullets[i].GetComponent<bulletMove_L9>().centrifugalRate = MaxGravity;
                }

                b1.centrifugalRate = MaxGravity;
                b2.centrifugalRate = MaxGravity;
            }
            else
            {
                for (int i = 0; i < bullets.Length; i++)
                {
                    bullets[i].GetComponent<bulletMove_L9>().centrifugalRate = MinGravity;
                }
                b1.centrifugalRate = MinGravity;
                b2.centrifugalRate = MinGravity;
            }

            isMin = !isMin;
            notPlayed = true;
        }

        if (CountDown <= 1 && notPlayed)
        {
            GravityChange.Play();
            notPlayed = false;
        }
	}
}
