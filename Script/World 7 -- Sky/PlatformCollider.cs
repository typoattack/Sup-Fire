using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour {
    private GameObject platform;
    private void Start()
    {
        platform = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        platform.SendMessage("SetPlayer", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        platform.SendMessage("SetPlayer", false);
    }
}
