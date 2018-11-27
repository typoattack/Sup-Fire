using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class IcicleMove : MonoBehaviour {
    public float bulletSpeed;
    public bool isFrozen;

    GameObject[] sparks;
    GameObject waterSplatter;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;
    public FloeDestroy staticIcicle;
    private GameObject iceSplatter;

    public AudioSource expSound;
    public AudioSource hitSound;
    public AudioSource waterSound;

    private bool damagded = false;
    private bool ifHit = false;

    private void Awake()
    {
        sparks = GameObject.FindGameObjectsWithTag("sparks");
        waterSplatter = GameObject.Find("FX_WaterSplatter");
    }
    void Start () {
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");
        //transform.Rotate(0f, 90f, 90f);

    }
    void SetFrozen(bool Frozen)//
    {
        isFrozen = Frozen;
    }

    void FixedUpdate () {
        //transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        //Debug.Log(transform);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall" || other.tag == "container" || other.tag == "icicle")
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            //0.8-1.5 as normal, 0.5-0.8 as big, need more modification
            hitSound.Play();
            //GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;
            CameraShaker.Instance.ShakeOnce(1f, 4f, 0f, 0.8f);
            if (other.tag == "wall" || other.tag == "container")
            {
                FloeDestroy newStaticIcicle = Instantiate(staticIcicle, transform.position+new Vector3(0,0,0.5f), transform.rotation) as FloeDestroy;
                newStaticIcicle.gameObject.SetActive(true);
                Destroy(gameObject);
                //Destroy(newSparks, 0.5f);
            }
        }
        else if (other.tag == "Player")
        {
            GameObject newExplosion = Instantiate(explosion[0], other.transform.position, transform.rotation) as GameObject;
            GameObject newDelay = Instantiate(delay[0], transform.position, transform.rotation) as GameObject;
            newDelay.SetActive(true);
            if (isFrozen)
            {
                other.transform.parent.SendMessage("Buff_Time", Time.time);

            }
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
        else if (other.tag == "Bullet")
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            hitSound.Play();
            iceSplatter = GameObject.Find("FX_IceSplatter");
            GameObject newSplatters = Instantiate(iceSplatter, transform.position, new Quaternion()) as GameObject;
            ParticleSystem SplattersParticle = newSplatters.GetComponent<ParticleSystem>();
            var main = SplattersParticle.main;
            main.startSize = 0.5f;
            main.startSpeed = 5f;
            Destroy(newSplatters, 1.5f);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.tag == "water")
        {
            waterSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            waterSound.Play();
            GameObject newSplatters = Instantiate(waterSplatter, transform.position, new Quaternion()) as GameObject;

            Destroy(gameObject);
            Destroy(newSplatters, 1.5f);
        }
        
    }
}
