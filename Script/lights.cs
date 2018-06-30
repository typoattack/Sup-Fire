using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour {
    public Material green;
    public Material red;
    void setgreen()
    {

        GetComponent<MeshRenderer>().material = green;

    }
    void setred()
    {
        GetComponent<MeshRenderer>().material = red;
    }
}
