using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {


	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("scene1-origin");
        }else if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("scene2-iceberg");
        }else if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("scene3-elevator");
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("scene4-volcano");
        }
    }
}
