using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    public Transform aroundPoint;
    public float angularSpeed;
    public float aroundRadius;
    private bool got;
    private float angled;
    void Start()
    {
        got = false;   
    }

    void Setangle(float ang)
    {
        angled = ang;
    }

    void FixedUpdate()

    {

        if (!got)
        {
            angled += (angularSpeed * Time.deltaTime) % 360;
            float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
            float posy = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);
            transform.position = new Vector3(posX, posy, 0) + aroundPoint.position;
            transform.rotation = Quaternion.Euler(angled, 90, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Missile")
            got = true;
    }
}

