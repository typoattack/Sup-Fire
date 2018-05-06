using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTrigger_underwater : MonoBehaviour {

    private GameObject target;

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f, -0.02f, 0f));
    }
    void got(GameObject target)
    {
        Collider capCo = GetComponent<Collider>();
        capCo.enabled = false;
        Destroy(gameObject, 0.5f);
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
            bulletMoveunderwater bullet = other.GetComponent<bulletMoveunderwater>();
            target = bullet.comeFrom;
            target.SendMessage("SetMulti");
            got(target);

        }
        else if (other.tag == "Missile")
        {
            MissileMoveUnderwater missile = other.GetComponent<MissileMoveUnderwater>();
            target = missile.comeFrom;
            target.SendMessage("SetMulti");
            got(target);

        }
    }
}
