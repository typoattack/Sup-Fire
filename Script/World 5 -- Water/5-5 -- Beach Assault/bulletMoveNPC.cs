using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class bulletMoveNPC : MonoBehaviour {
    public float bulletSpeed;
    public GameObject comeFrom;

    GameObject[] sparks;
    GameObject waterSplatter;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;

    public AudioSource expSound;
    public AudioSource hitSound;
    public AudioSource waterSound;

    public float effectSize;

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
    
    void FixedUpdate () {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        //Debug.Log(transform);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "wall"||other.tag=="container")
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            //0.8-1.5 as normal, 0.5-0.8 as big, need more modification
            hitSound.Play();
            GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;
            newSparks.transform.localScale = new Vector3(effectSize, effectSize, effectSize);
            CameraShaker.Instance.ShakeOnce(1f, 4f, 0f, 0.8f);
            
            Destroy(gameObject);
            Destroy(newSparks, 0.5f);
        }
        else if (other.tag == "Player" || other.tag == "Building")
        {
            GameObject newExplosion = Instantiate(explosion[0], transform.position, transform.rotation) as GameObject;
            newExplosion.transform.localScale = new Vector3(effectSize, effectSize, effectSize);
            GameObject newDelay = Instantiate(delay[0], transform.position, transform.rotation) as GameObject;
            newDelay.SetActive(true);
            
            expSound.pitch = Random.Range(0.7f, 1.5f);
            expSound.Play();

            CameraShaker.Instance.ShakeOnce(3f, 20f, 0f, 0.5f);
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
    }
}
