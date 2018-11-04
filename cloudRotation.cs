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
    private float platformHVelocity;
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
            platformHVelocity = aroundRadius * (Mathf.Cos(angled * Mathf.Deg2Rad))/2.86f;
            other.transform.parent.SendMessage("SetPlatformVelocity", platformHVelocity);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            platformHVelocity = 0f;
            other.transform.parent.SendMessage("SetPlatformVelocity", platformHVelocity);
        }
    }
}
