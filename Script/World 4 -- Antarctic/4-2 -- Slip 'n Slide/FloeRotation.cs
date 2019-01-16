using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloeRotation : MonoBehaviour {

    public float angularSpeed;

    void FixedUpdate()

    {
        transform.Rotate(0, angularSpeed, 0);
    }
}
