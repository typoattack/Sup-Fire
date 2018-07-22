using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Mine : MonoBehaviour {
    public GameObject big;
    public GameObject multi;
    public GameObject missile;
    public GameObject frozen;
    public int itself;

    GameObject[] explosion;
    GameObject[] delay;

    public AudioSource expSound;

    private bool damagded = false;

    // Use this for initialization
    void Start ()
    {
        itself = Random.Range(0, 3);
        explosion = GameObject.FindGameObjectsWithTag("explosion");
        delay = GameObject.FindGameObjectsWithTag("delay");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag=="Missile" || other.gameObject.tag == "Player")
        {
            switch (itself)
            {
                case 0:
                   GameObject powerup0= Instantiate(big, transform.position,Quaternion.identity)as GameObject;
                    powerup0.SetActive(true);
                    break;
                case 1:
                    GameObject powerup1 = Instantiate(multi, transform.position, Quaternion.identity) as GameObject;
                    powerup1.SetActive(true);
                    break;
                case 2:
                    GameObject powerup2 = Instantiate(missile, transform.position, Quaternion.identity) as GameObject;
                    powerup2.SetActive(true);
                    break;
                case 3:
                    GameObject powerup3 = Instantiate(frozen, transform.position, Quaternion.identity) as GameObject;
                    powerup3.SetActive(true);
                    break;
                default:
                    break;

            }
            
            if (other.gameObject.tag == "Player")
            {
                GameObject newExplosion = Instantiate(explosion[0], transform.position, transform.rotation) as GameObject;
                GameObject newDelay = Instantiate(delay[0], transform.position, transform.rotation) as GameObject;
                newDelay.SetActive(true);

                expSound.pitch = Random.Range(0.7f, 1.5f);
                expSound.Play();

                CameraShaker.Instance.ShakeOnce(3f, 20f, 0f, 0.5f);

                Destroy(newExplosion, 2.0f);
                Destroy(newDelay, 2.0f);

                other.transform.parent.SendMessage("SetLife", -1);
                damagded = !damagded;

                
            }
         
            Destroy(gameObject);

        }
        

                

    }

}
