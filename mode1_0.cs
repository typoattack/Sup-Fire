using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mode1_0 : MonoBehaviour {

    public Material normal;
    public Material selected;
    public GameObject Sceneselect;
    public GameObject select2;
    // Use this for initialization
    void Start()
    {
        GetComponent<MeshRenderer>().material = normal;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 2f);
            Destroy(transform.parent.gameObject, 2f);
            GetComponent<MeshRenderer>().material = selected;
           // SceneManager.LoadScene("scene7-underwater");
            //GameObject.Find("BGM-Manager").SendMessage("SetLevel", 0);
            //Sceneselect.SendMessage("Mode", 1);
           
            

        }
    }
}
