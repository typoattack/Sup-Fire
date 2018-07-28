using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class LavaMove : MonoBehaviour {

    public float LavaSpeed;

    GameObject[] sparks;
    GameObject[] explosion;
    GameObject[] delay;
    GameObject[] hit;

    public AudioSource expSound;
    public AudioSource hitSound;

    private bool damagded = false;

    private void Awake()
    {
        sparks = GameObject.FindGameObjectsWithTag("sparks");

    }
    void Start()
    {
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");
        transform.Rotate(0f, 90f, 90f);

    }

  

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * LavaSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "wall")
        {
            hitSound.pitch = 0.1f * 1.05946f * Random.Range(8, 15);
            hitSound.Play();
            GameObject newSparks = Instantiate(sparks[0], transform.position, transform.rotation) as GameObject;
            CameraShaker.Instance.ShakeOnce(0.6f, 3f, 0f, 1.0f);
            
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

            Destroy(gameObject);
            Destroy(newExplosion, 2.0f);
            Destroy(newDelay, 2.0f);
            if (!damagded)
            {
                other.transform.parent.SendMessage("SetLife", -1);
                damagded = !damagded;
            }
        }

        else if (other.tag == "lava")
        {
            Destroy(gameObject);
        }
    }
}
