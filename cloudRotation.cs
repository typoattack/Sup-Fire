using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudRotation : MonoBehaviour {

    public Transform aroundPoint;
    public float startAngle;
    public float angularSpeed;
    public float aroundRadius;
    public bool rotating;
    private bool got;
    private float angled;
    void Start()
    {
        got = false;
        angled = startAngle;
    }

    void Setangle(float ang)
    {
        angled = ang;
    }

    void FixedUpdate()

    {
        angled += (angularSpeed * Time.deltaTime) % 360;
        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posy = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);
        transform.position = new Vector3(posX, posy, 0) + aroundPoint.position;
        if (rotating)
        {
            transform.rotation = Quaternion.Euler(0, 0, -angled);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SendMessage("SetPlatformVelocity", aroundRadius * (1 / Mathf.Tan(angled * Mathf.Deg2Rad)) * Mathf.Cos(angled * Mathf.Deg2Rad));
        }
    }
}
