using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour {

    public Animator BodyAnim;
    public float SwaingAngle;
    public float SwaingSpeed;

    private Transform Turret;

    private void Start()
    {
        Turret = gameObject.transform.GetChild(1);
    }

    private void FixedUpdate()
    {
        BodyAnim.Play("body Animation");
        float offset = Mathf.PingPong(Time.time * SwaingSpeed, SwaingAngle);
        Turret.rotation = new Quaternion(0f, 0f, -0.5f * SwaingAngle + offset, 1f);
    }
}
