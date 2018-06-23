using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrigger_test : MonoBehaviour {

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
            BulletMove_test bullet = other.GetComponent<BulletMove_test>();
            target = bullet.comeFrom;
            target.SendMessage("SetMissile");
            got(target);
        }
        else if (other.tag == "Missile")
        {
            MissileMove_test missile = other.GetComponent<MissileMove_test>();
            target = missile.comeFrom;
            target.SendMessage("SetMissile");
            got(target);
        }
    }
}