using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTrigger_L8 : MonoBehaviour {

    private GameObject target;

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f, -0.02f, 0f));
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
            bulletMove_L8 bullet = other.GetComponent<bulletMove_L8>();
            target = bullet.comeFrom;
            target.SendMessage("SetMulti");
            got(target);

        }
        else if (other.tag == "Missile")
        {
            MissileMove_L8 missile = other.GetComponent<MissileMove_L8>();
            target = missile.comeFrom;
            target.SendMessage("SetMulti");
            got(target);

        }
    }
}
