using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class IcicleMoveNew : MonoBehaviour {

    
    GameObject[] sparks;
    GameObject waterSplatter;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;
    private GameObject iceSplatter;
    public AudioSource expSound;
    public AudioSource hitSound;
   

    private bool damagded = false;
    private bool ifHit = false;
    private bool ifdestory = false;
    private float temp;
    public float cd;
    private void Awake()
    {
        sparks = GameObject.FindGameObjectsWithTag("sparks");
        waterSplatter = GameObject.Find("FX_WaterSplatter");
    }
    void Start()
    {
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");


    }


    void FixedUpdate()
    {
        if (ifHit == true)
        {
            if (Time.time - temp >= cd&&temp>=0.5f)
            { foreach (Transform child in transform)
                {
                    child.gameObject.SendMessage("setflag", true);
                    child.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                }
            }


        }

    }





    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "wall"&&ifHit==false)
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            //0.8-1.5 as normal, 0.5-0.8 as big, need more modification
            hitSound.Play();
            //GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;

            ifHit = true;
            temp = Time.time;
            foreach (Transform child in transform)
                child.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<MeshCollider>().isTrigger = false;

        }

        else if (other.tag == "Player"&&ifHit==false)
        {
            GameObject newExplosion = Instantiate(explosion[0], other.transform.position, transform.rotation) as GameObject;
            GameObject newDelay = Instantiate(delay[0], transform.position, transform.rotation) as GameObject;
            newDelay.SetActive(true);
            expSound.pitch = Random.Range(0.7f, 1.5f);
            expSound.Play();

            CameraShaker.Instance.ShakeOnce(3f, 20f, 0f, 0.5f);
            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);
            if (!damagded)
            {
                other.transform.parent.SendMessage("SetLife", -1);
                damagded = !damagded;

            }

        }
        else if (other.gameObject.tag == "icicle" && ifHit == false)
        {

            Destroy(other.gameObject);
        }


    }
}

