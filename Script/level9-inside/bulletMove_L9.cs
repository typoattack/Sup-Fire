using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class bulletMove_L9 : MonoBehaviour {
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


    //L9
    public float centrifugalRate;
    public PipeMove pipe;
    private static float pipeRedius = 10.6f;
    private Rigidbody rb;
    private Vector3 velocity;
    //

    private bool damagded = false;

    private void Awake()
    {
        sparks = GameObject.FindGameObjectsWithTag("sparks");
        waterSplatter = GameObject.Find("FX_WaterSplatter");
    }
    void Start () {
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");
        transform.Rotate(0f, 90f, 90f);
        //L9 not yer valid;
        //rb = GetComponent<Rigidbody>();
        //Debug.Log(Vector3.ProjectOnPlane(transform.Rotate.rotation.eulerAngles, Vector3.forward));
        //Vector3 veject = Vector3.ProjectOnPlane(Vector3.Normalize(transform.rotation.eulerAngles),  Vector3.forward) * bulletSpeed;
        //float vh = pipe.angularVelocity / 360 * 2 * Mathf.PI * pipeRedius;
        //Vector3 angle = Vector3.Normalize(transform.position - pipe.transform.position);
        //Vector3 vpipe = new Vector3(pipe.clockwise ? angle.y : -angle.y, pipe.clockwise ? -angle.x : angle.x, 0f) * vh;
        //velocity = veject + vpipe;
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
        ////L9 Optional
        //transform.position += velocity *Time.deltaTime;
        //Vector3 centrifugal = (transform.position - new Vector3(pipe.transform.position.x, pipe.transform.position.y, transform.position.z)) / pipeRedius;
        //rb.AddForce(centrifugal * centrifugalRate, ForceMode.Impulse);
        ////
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
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
                CameraShaker.Instance.ShakeOnce(2f, 4f, 0f, 3f);
            }
            else
            {
                CameraShaker.Instance.ShakeOnce(1.25f, 4f, 0f, 1.0f);
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
        else if (other.tag == "sub")
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            //0.8-1.5 as normal, 0.5-0.8 as big, need more modification
            hitSound.Play();
            GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;
            if (isBig)
            {
                newSparks.transform.localScale = new Vector3(2f, 2f, 2f);
                CameraShaker.Instance.ShakeOnce(2f, 4f, 0f, 3f);
            }
            else
            {
                CameraShaker.Instance.ShakeOnce(1.25f, 4f, 0f, 1.0f);
            }
            if (comeFrom.activeSelf)
            {
                comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            }
            Destroy(gameObject);
            Destroy(newSparks, 0.5f);
            if (comeFrom.name == "Player1") SubMover.torpedohitcountleft++;
            if (comeFrom.name == "Player2") SubMover.torpedohitcountright++;
        }


    }
}
