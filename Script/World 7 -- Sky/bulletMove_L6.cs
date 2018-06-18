using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class bulletMove_L6 : MonoBehaviour {
    public float bulletSpeed;
    public GameObject comeFrom;
    public bool isMulti;
    public bool isBig;
    public bool isFrozen;//

    GameObject[] sparks;
    GameObject waterSplatter;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;

    public AudioSource expSound;
    public AudioSource hitSound;
    public AudioSource waterSound;

    public ParticleSystem fireBall;
    public float MaxBulletSpeed;
    private bool damagded = false;
    private Rigidbody rigid;
    
        private void Awake()
    {
        sparks = GameObject.FindGameObjectsWithTag("sparks");
        waterSplatter = GameObject.Find("FX_WaterSplatter");
    }
    void Start () {
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");
        transform.Rotate(0f, 90f, 90f);
        fireBall.gameObject.SetActive(false);
        rigid = gameObject.GetComponent<Rigidbody>();
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

    void BurnUp()
    {
        fireBall.gameObject.SetActive(true);
        StartCoroutine(bulletDelay(2.4f));
        Destroy(gameObject, 2.5f);
    }

    IEnumerator bulletDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (comeFrom.activeSelf)
        {
            comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
        }
    }

    void FixedUpdate () {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        //L6
        //if (gameObject != null && transform.position.y < -6f) {
            //Destroy(gameObject);
            //if (comeFrom.activeSelf)
            //{
                //comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            //}
        //}
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > MaxBulletSpeed)
        {
            BurnUp();
        }

        if (gameObject.transform.position.y < -7)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 7f, gameObject.transform.position.z);
            //rigid.velocity = Vector3.zero;
        }else if(gameObject.transform.position.y > 7.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -6.5f, gameObject.transform.position.z);

        }

        if (gameObject.transform.position.x < -12)
        {
            gameObject.transform.position = new Vector3(11.5f, gameObject.transform.position.y, gameObject.transform.position.z);
            //rigid.velocity = Vector3.zero;
        }
        else if (gameObject.transform.position.x > 12f)
        {
            gameObject.transform.position = new Vector3( -11.5f, gameObject.transform.position.y, gameObject.transform.position.z);

        }

        if (rigid.velocity.magnitude > MaxBulletSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * MaxBulletSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "wall")
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
        }else if (other.tag == "Player")
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
    }
}
