using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BulletMoveShrinkandEnlarge : MonoBehaviour {
    private float parameter;
    private Vector3 size;
    private Animator a;
    private void Start()
    {
        parameter = 1;
        size = transform.localScale;
        a = gameObject.GetComponent<Animator>();
        //Debug.Log(transform.localScale);
    }

    private void Update()
    {
        a.enabled = parameter == 1 ? true : false;
        transform.localScale = parameter * size;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "large")
        {
            parameter = 2;
        }
        else if (other.gameObject.tag == "small")
        {
            parameter = 0.5f;
        }

    }



}
