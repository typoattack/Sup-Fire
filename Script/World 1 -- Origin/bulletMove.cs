using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class bulletMove : MonoBehaviour {
    public float bulletSpeed;
    public GameObject comeFrom;
    public bool isMulti;
    public bool isBig;
    public bool isFrozen;//
    public LavaMove lavaSplatter;
    public float lavaSpwanLoc;

    GameObject[] sparks;
    GameObject waterSplatter;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;

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
        transform.Rotate(0f, 90f, 90f);
  
    }

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

    void FixedUpdate () {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "wall"||other.tag=="container")
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            //0.8-1.5 as normal, 0.5-0.8 as big, need more modification
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
            if (isBig)
            {
                newExplosion.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            else if (isFrozen)//
            {
                other.transform.parent.SendMessage("Buff_Time", Time.time);

            }
            expSound.pitch = Random.Range(0.7f, 1.5f);
            expSound.Play();

            CameraShaker.Instance.ShakeOnce(isBig ? 6f : 3f, 20f, 0f, 0.5f);
            comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);
            if (!damagded)
            {
                other.transform.parent.SendMessage("SetLife", isBig ? -2 : -1);
                damagded = !damagded;

            }

        }
        else if (other.tag == "water")
        {
            waterSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            waterSound.Play();
            GameObject newSplatters = Instantiate(waterSplatter, transform.position, new Quaternion()) as GameObject;
            if (isBig)
            {
                ParticleSystem SplattersParticle = newSplatters.GetComponent<ParticleSystem>();
                var main = SplattersParticle.main;
                main.startSize = 0.4f;
                main.startSpeed = 5f;
            }

            if (comeFrom.activeSelf)
            {
                comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            }

            Destroy(gameObject);
            Destroy(newSplatters, 1.5f);
        }

        else if (other.tag == "lava")
        {
            waterSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            waterSound.Play();

            GameObject newSplatters = Instantiate(waterSplatter, transform.position, new Quaternion()) as GameObject;
            
            LavaMove newLava1 = Instantiate(lavaSplatter, new Vector3(transform.position.x , lavaSpwanLoc, transform.position.z), new Quaternion()) as LavaMove;
            LavaMove newLava2 = Instantiate(lavaSplatter, new Vector3(transform.position.x, lavaSpwanLoc, transform.position.z), new Quaternion()) as LavaMove;

            newLava1.gameObject.SetActive(true);
            newLava1.transform.Rotate(new Vector3(0f, 0f, isBig ? -20f : -45f));
            newLava1.GetComponent<Rigidbody>().AddForce(0f, 16f, 0f);

            newLava2.gameObject.SetActive(true);
            newLava2.transform.Rotate(new Vector3(0f, 0f, isBig ? 20f : 45f));
            newLava2.GetComponent<Rigidbody>().AddForce(0f, 16f, 0f);

            if (isBig)
            {
                ParticleSystem SplattersParticle = newSplatters.GetComponent<ParticleSystem>();
                var main = SplattersParticle.main;
                main.startSize = 0.4f;
                main.startSpeed = 5f;

                LavaMove newLava3 = Instantiate(lavaSplatter, new Vector3(transform.position.x, lavaSpwanLoc, transform.position.z), new Quaternion()) as LavaMove;
                LavaMove newLava4 = Instantiate(lavaSplatter, new Vector3(transform.position.x, lavaSpwanLoc, transform.position.z), new Quaternion()) as LavaMove;

                newLava3.gameObject.SetActive(true);
                newLava3.transform.Rotate(new Vector3(0f, 0f, -80f));
                newLava3.GetComponent<Rigidbody>().AddForce(0f, 20f, 0f);

                newLava4.gameObject.SetActive(true);
                newLava4.transform.Rotate(new Vector3(0f, 0f, 80f));
                newLava4.GetComponent<Rigidbody>().AddForce(0f, 20f, 0f);
            }

            if (comeFrom.activeSelf)
            {
                comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            }

            Destroy(gameObject);
            Destroy(newSplatters, 1.5f);

        }
    }
}
