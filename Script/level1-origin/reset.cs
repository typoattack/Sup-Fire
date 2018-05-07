using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class reset : MonoBehaviour {

    private Scene scene;


    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Cursor.visible = false;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKey (KeyCode.Escape) && Input.GetKey(KeyCode.Tab)){
            SceneManager.LoadScene(scene.name);
            SceneManager.LoadScene("scene1-origin");
            ScoreInfo info = GameObject.Find("ScoreInfo").GetComponent<ScoreInfo>();
            SceneSwitch swith = GameObject.Find("SceneSwitch").GetComponent<SceneSwitch>();
            info.left = 0;
            info.right = 0;
            swith.sceneCount = 0;
        }
    }
}
