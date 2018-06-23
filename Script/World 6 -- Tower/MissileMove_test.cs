﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class MissileMove_test : MonoBehaviour {


    public float bulletSpeed;
    public float initialSpeed;
    public float rotateSpeed;
    public float delayTime;

    public GameObject comeFrom;
    public GameObject target;

    float angle;
    Rigidbody rigid;


    GameObject[] sparks;
    GameObject[] explosion;
    GameObject waterSplatter;
    GameObject[] delay;
    GameObject[] MissileTrail;
    GameObject newMissileTrail;
    //   bool hit = false;

    public AudioSource expSound;
    public AudioSource hitSound;
    public AudioSource waterSound;

    float startTime;

    public bool isMulti;
    public bool isBig;
    public bool isFrozen;//

    void SetMulti(bool multi)
    {
        isMulti = multi;
    }

    void SetBig(bool big)
    {
        isBig = big;
    }
    void SetFrozen(bool Frozen)//
    {
        isFrozen = Frozen;
    }
    private void Awake()
    {
        sparks = GameObject.FindGameObjectsWithTag("sparks");
        waterSplatter = GameObject.Find("FX_WaterSplatter");
    }
    void Start()
    {
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");

        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.up * initialSpeed);
        MissileTrail = GameObject.FindGameObjectsWithTag("MissileTrail");
        newMissileTrail = Instantiate(MissileTrail[0], transform.position, transform.rotation) as GameObject;
        //        newMissileTrail.SetActive(false);
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if (Time.time - startTime > 0.5 * delayTime)
        {

            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();

            angle = Vector3.Cross(direction, transform.up).z;
            rigid.angularVelocity = new Vector3(0f, 0f, -angle * rotateSpeed);
        }


        newMissileTrail.transform.position = transform.position - 1.5f * transform.up;
        if (Time.time - startTime > delayTime)
        {
            rigid.AddForce(transform.up * (Time.time - startTime) * bulletSpeed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            hitSound.pitch = 0.5f * 1.05946f * Random.Range(1, 4);
            // 0.75-1.5
            hitSound.Play();
            GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;

            if (isBig)
            {
                newSparks.transform.localScale = new Vector3(2f, 2f, 2f);
                CameraShaker.Instance.ShakeOnce(1.5f, 4f, 0f, 2f);
            }
            else
            {
                CameraShaker.Instance.ShakeOnce(1f, 4f, 0f, 0.8f);
            }
            if (comeFrom.activeSelf)
            {
                comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            }
            Destroy(gameObject);
            Destroy(newSparks, 0.5f);

        }
        else if (other.tag == "Player")
        {
            GameObject newExplosion = Instantiate(explosion[0], transform.position, transform.rotation) as GameObject;
            GameObject newDelay = Instantiate(delay[0], transform.position, transform.rotation) as GameObject;
            newDelay.SetActive(true);

            expSound.pitch = Random.Range(0.7f, 1.5f);
            expSound.Play();

            CameraShaker.Instance.ShakeOnce(3f, 20f, 0f, 1f);


            if (isBig)
            {
                newExplosion.transform.localScale = new Vector3(2f, 2f, 2f);
                other.transform.parent.SendMessage("SetLife", -1);
            }
            if (isFrozen)//
            {
                other.transform.parent.SendMessage("Buff_Time", Time.time);
                

            }
            comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            other.transform.parent.SendMessage("SetLife", -1);


            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);

        }


        /*ParticleSystem P = newMissileTrail.GetComponent<ParticleSystem>();
        var em = P.emission;
        em.enabled = false;*/
        Destroy(newMissileTrail, 3.0f);



    }
}

