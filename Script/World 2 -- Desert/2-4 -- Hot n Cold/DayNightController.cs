using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {

    public GameObject WindLR;
    public GameObject WindRL;
    public GameObject DayPlane;
    public GameObject NightPlane;
    public GameObject SunMoonPanel;
    public Material backMaterial;
    public float windInt = 0.25f;

    public float DayNightCycle;
    public Material lerpedMaterial1;
    public Material lerpedMaterial2;
    public bulletMove b1;
    public bulletMove b2;
    public MissileMove m1;
    public MissileMove m2;

    private float timer;
    private bulletMove[] allBullet;
    private MissileMove[] allMissile;
    float bv;
    float mv;
    [HideInInspector] public static float wind;
    
	void Start () {
        timer = 0;
        backMaterial.color = lerpedMaterial1.color;
        WindLR.SetActive(true);
        WindRL.SetActive(false);
        bv = Mathf.Abs(b1.windForce);
        mv = Mathf.Abs(m1.windForce);
    }

    void Resetweapon()
    {
        allBullet = FindObjectsOfType<bulletMove>();
        allMissile = FindObjectsOfType<MissileMove>();

        for (int i = 0; i < allBullet.Length; i++)
        {
            allBullet[i].windForce = WindLR.activeSelf? bv : -bv;
        }

        for (int i = 0; i < allMissile.Length; i++)
        {
            allMissile[i].windForce = WindLR.activeSelf ? mv : -mv;
        }

        b1.windForce = WindLR.activeSelf ? bv : -bv;
        b2.windForce = WindLR.activeSelf ? bv : -bv;
        m1.windForce = WindLR.activeSelf ? mv : -mv;
        m2.windForce = WindLR.activeSelf ? mv : -mv;
    }

    void Update()
    {
        SunMoonPanel.transform.Rotate(0, 0, -180/DayNightCycle* Time.deltaTime);
        timer += Time.deltaTime;


        if (timer > 0.8 * DayNightCycle && timer <= DayNightCycle)
        {
            backMaterial.color = Color.Lerp(lerpedMaterial1.color, lerpedMaterial2.color, (timer - 0.8f * DayNightCycle) / (0.2f * DayNightCycle));
        }
        else if (timer >= DayNightCycle && timer < DayNightCycle * 1.01f)
        {
            WindLR.SetActive(false);
            WindRL.SetActive(true);
            Resetweapon();
        }
        else if (timer > 1.8 * DayNightCycle && timer < DayNightCycle * 2)
        {
            backMaterial.color = Color.Lerp(lerpedMaterial2.color, lerpedMaterial1.color, (timer - 1.8f * DayNightCycle) / (0.2f * DayNightCycle));
        } else if (timer >= DayNightCycle * 2)
        {
            timer = 0f;
            WindLR.SetActive(true);
            WindRL.SetActive(false);
            Resetweapon();
        }
    }
}
