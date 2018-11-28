using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMissile : MonoBehaviour {
    GameObject p1;
    GameObject p2;
    Controller_P1_w8_biStar c1;
    Controller_P2_w8_biStar c2;

    void Start () {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        p1.GetComponent<Controller_P1_w8_biStar>().SetMissile();
        p2.GetComponent<Controller_P2_w8_biStar>().SetMissile();
    }

    // Update is called once per frame
    void Update () {
        p1.GetComponent<Controller_P1_w8_biStar>().SetMissile();
        p2.GetComponent<Controller_P2_w8_biStar>().SetMissile();
    }
}
