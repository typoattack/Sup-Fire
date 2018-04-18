using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class bulletMove : MonoBehaviour {
    public float bulletSpeed;
    public GameObject comeFrom;
    public bool isMulti;
    public bool isBig;
    
    //projectile parameters
    private LineRenderer lineRenderer;
    private int posCount;
    private Vector3 velocity;


    GameObject[] sparks;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;

    public AudioSource expSound;
    public AudioSource hitSound;




    void Start () {
        sparks = GameObject.FindGameObjectsWithTag("sparks");
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");
        transform.Rotate(0f, 0f, 90f);

        //parabola calculation part
        lineRenderer = GetComponent<LineRenderer>();
        velocity = transform.rotation * Vector3.right * bulletSpeed * Time.deltaTime;
        posCount = 1;
        for ( Vector3 p = transform.position, v = velocity;  p.y > -4.0f && p.x >= -8.4f && p.x <= 8.4f; posCount++)
        {
            p += v;
            v += Physics.gravity * Time.deltaTime * Time.deltaTime;
        }
        //Debug.Log(posCount); 
        
    }

    void SetMulti(bool multi)
    {
        isMulti = multi;
    }

    void SetBig(bool big)
    {
        isBig = big;
    }

    void FixedUpdate () {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);

        //draw parabola
        if (posCount > 0)
        {
            posCount--;
            velocity += Physics.gravity * Time.deltaTime * Time.deltaTime;
        }
        lineRenderer.positionCount = posCount;

        Vector3 p = transform.position, v = velocity;
        for (int i = 0; i < posCount; i++)
        {
            lineRenderer.SetPosition(i, p);
            p += v;
            v += Physics.gravity * Time.deltaTime * Time.deltaTime;
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
                CameraShaker.Instance.ShakeOnce(3f, 4f, 0f, 3f);
            }
            else
            {
                CameraShaker.Instance.ShakeOnce(1.25f, 4f, 0f, 1.5f);
            }
            comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f: 1f);
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
            expSound.pitch = Random.Range(0.7f, 1.5f);
            expSound.Play();

            CameraShaker.Instance.ShakeOnce(isBig ? 6f : 3f, 20f, 0f, 1f);
            comeFrom.SendMessage("SetAmmo", isMulti ? 0.5f : 1f);
            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);
            other.transform.parent.SendMessage("SetLife", isBig ? -2 : -1);
        }

        
    }
}
