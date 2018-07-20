using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcebergMover : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f, 0f, -0.02f));
        Destroy(gameObject, 12f);
    }
}