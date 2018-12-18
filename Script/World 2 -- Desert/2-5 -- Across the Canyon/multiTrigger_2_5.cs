using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTrigger_2_5 : MonoBehaviour {

    private GameObject target;
    private float wind;

    private void Start()
    {
        wind = WindController.wind;
    }

    void FixedUpdate()
    {
        wind = WindController.wind;
        if (wind < 0.0f) transform.Translate(new Vector3(0f, -0.02f, 0f));
        if (wind > 0.0f) transform.Translate(new Vector3(0f, 0.02f, 0f));
    }
    void got(GameObject target)
    {
        Collider capCo = GetComponent<Collider>();
        capCo.enabled = false;
        Destroy(gameObject, 1.5f);
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce((-transform.position + target.transform.position) * 50f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Bullet")
        {
            bulletMove_2_5 bullet = other.GetComponent<bulletMove_2_5>();
            target = bullet.comeFrom;
            target.SendMessage("SetMulti");
            got(target);

        }
        else if (other.tag == "Missile")
        {
            MissileMove_2_5 missile = other.GetComponent<MissileMove_2_5>();
            target = missile.comeFrom;
            target.SendMessage("SetMulti");
            got(target);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
