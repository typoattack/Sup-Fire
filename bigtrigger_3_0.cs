using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigtrigger_3_0 : MonoBehaviour {

    private GameObject target;

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f, 0.02f, 0f));
    }
    void got(GameObject target)
    {
        Collider capCo = GetComponent<Collider>();
        capCo.enabled = false;
        Destroy(gameObject, 1.5f);
        Rigidbody rigid = GetComponent<Rigidbody>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
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
            bulletMove bullet = other.GetComponent<bulletMove>();
            target = bullet.comeFrom;
            target.SendMessage("SetBig");
            got(target);

        }
        else if (other.tag == "Missile")
        {
            MissileMove missile = other.GetComponent<MissileMove>();
            target = missile.comeFrom;
            target.SendMessage("SetBig");
            got(target);

        }
    }
}
