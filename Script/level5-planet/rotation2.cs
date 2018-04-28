using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation2 : MonoBehaviour
{

    public Transform aroundPoint;
    public float angularSpeed;
    public float aroundRadius;

    private float angled;
    void Start()
    {
        angled = 90;

        transform.position = new Vector3(1.5f, 0f, -0.56f);
        transform.rotation = Quaternion.Euler(angled, 90, 0);

    }

    void FixedUpdate()

    {

        float dir = Input.GetAxis("J-Vertical"); 
        angled -= dir*(angularSpeed * Time.deltaTime) % 360;
        angled = Mathf.Clamp(angled, 20, 160);
        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posy = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);
        transform.position = new Vector3(posX, posy, 0) + aroundPoint.position;
        transform.rotation = Quaternion.Euler(angled, 90, 0);
    }
}