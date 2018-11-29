using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class MissileMove : MonoBehaviour {

    public float bulletSpeed;
    public float initialSpeed;
    public float rotateSpeed;
    public float delayTime;

    public GameObject comeFrom;
    public GameObject target;
    public LavaMove lavaSplatter;

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
        if(Time.time - startTime > delayTime)
        {
            rigid.AddForce(transform.up * (Time.time - startTime) * bulletSpeed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall"||other.tag=="container" || other.tag == "icicle")
        {
            hitSound.pitch = 0.5f * 1.05946f * Random.Range(1, 4);
            // 0.75-1.5
            hitSound.Play();
            GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;

            CameraShaker.Instance.ShakeOnce(1.5f, 4f, 0f, 1.5f);
            //comeFrom.SendMessage("SetAmmo", 1f);
 //           if (!hit)
            {
                comeFrom.SendMessage("SetAmmo", 1f);
 //               hit = true;
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

 //           if (!hit)
            {
                other.transform.parent.SendMessage("SetLife", -1);
                comeFrom.SendMessage("SetAmmo", 1f);
 //               hit = true;
            }

            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);

        }
        else if (other.tag == "water")
        {
            waterSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            waterSound.Play();
            if (comeFrom.activeSelf)
            {
                comeFrom.SendMessage("SetAmmo", 1f);
            }
            GameObject newSplatters = Instantiate(waterSplatter, transform.position, new Quaternion()) as GameObject;
            Destroy(gameObject);
            Destroy(newSplatters, 1.5f);
        }

        else if (other.tag == "lava")
        {
            waterSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            waterSound.Play();

            GameObject newSplatters = Instantiate(waterSplatter, transform.position, new Quaternion()) as GameObject;

            LavaMove newLava1 = Instantiate(lavaSplatter, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), new Quaternion()) as LavaMove;
            LavaMove newLava2 = Instantiate(lavaSplatter, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), new Quaternion()) as LavaMove;

            newLava1.gameObject.SetActive(true);
            newLava1.transform.Rotate(new Vector3(0f, 0f, -45f));
            newLava1.GetComponent<Rigidbody>().AddForce(0f, 18f, 0f);

            newLava2.gameObject.SetActive(true);
            newLava2.transform.Rotate(new Vector3(0f, 0f, 45f));
            newLava2.GetComponent<Rigidbody>().AddForce(0f, 18f, 0f);

            if (comeFrom.activeSelf)
            {
                comeFrom.SendMessage("SetAmmo", 1f);
            }

            Destroy(gameObject);
            Destroy(newSplatters, 1.5f);

        }

        ParticleSystem P = newMissileTrail.GetComponent<ParticleSystem>();
        var em = P.emission;
        em.enabled = false;
        Destroy(newMissileTrail, 3.0f);
        }
        
}
