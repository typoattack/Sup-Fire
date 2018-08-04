using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MissileMoveNPC : MonoBehaviour {

    public float bulletSpeed;
    public float initialSpeed;
    public float rotateSpeed;
    public float delayTime;

    public GameObject comeFrom;
    private GameObject target;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    private float chooseTarget;

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
    public float effectSize;

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
        newMissileTrail.transform.localScale = new Vector3(effectSize, effectSize, effectSize);
        startTime = Time.time;
        chooseTarget = Random.Range(0.0f, 3.0f);
        if (chooseTarget >= 0.0f && chooseTarget < 1.0f) target = target1;
        else if (chooseTarget >= 1.0f && chooseTarget < 2.0f) target = target2;
        else target = target3;
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
            rigid.AddForce(transform.up * (Time.time - startTime) * bulletSpeed / 4.0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall" || other.tag == "container")
        {
            hitSound.pitch = 0.5f * 1.05946f * Random.Range(1, 4);
            // 0.75-1.5
            hitSound.Play();
            GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;
            newSparks.transform.localScale = new Vector3(effectSize, effectSize, effectSize);

            CameraShaker.Instance.ShakeOnce(1.5f, 4f, 0f, 1.5f);
            //comeFrom.SendMessage("SetAmmo", 1f);
            //           if (!hit)
            
            Destroy(gameObject);
            Destroy(newSparks, 0.5f);

        }
        else if (other.tag == "Player" || other.tag == "Building")
        {
            GameObject newExplosion = Instantiate(explosion[0], transform.position, transform.rotation) as GameObject;
            if (other.tag == "Player") newExplosion.transform.localScale = new Vector3(effectSize, effectSize, effectSize);
            else newExplosion.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            GameObject newDelay = Instantiate(delay[0], transform.position, transform.rotation) as GameObject;
            newDelay.SetActive(true);

            expSound.pitch = Random.Range(0.7f, 1.5f);
            expSound.Play();

            CameraShaker.Instance.ShakeOnce(3f, 20f, 0f, 1f);
            
            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);

        }
        else if (other.tag == "water")
        {
            waterSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            waterSound.Play();
            
            GameObject newSplatters = Instantiate(waterSplatter, transform.position, new Quaternion()) as GameObject;
            newSplatters.transform.localScale = new Vector3(effectSize, effectSize, effectSize);
            Destroy(gameObject);
            Destroy(newSplatters, 1.5f);
        }

        ParticleSystem P = newMissileTrail.GetComponent<ParticleSystem>();
        var em = P.emission;
        em.enabled = false;
        Destroy(newMissileTrail, 3.0f);



    }
}

