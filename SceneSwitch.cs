using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public int addedScenesNum;
    public int thisScenesNum;
    public int sceneCount;

    void Switch(){
        if (addedScenesNum - 1 <= sceneCount)
        {
            sceneCount = 0;
        }
        else
        {
            sceneCount += 1;
        }

        StartCoroutine(DelayTime(1.0f, sceneCount));
        GameObject.Find("BGM-Manager").SendMessage("SetLevel", sceneCount);
    }

    IEnumerator DelayTime(float duration, int sceneCount)
    {
        GameObject.Find("FadeInOut").GetComponent<fading>().BeginFade(1);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneBuildIndex: sceneCount);

    }

    void End()
    {
        //SceneManager.LoadScene("End Scene");
        StartCoroutine(DelayTime(1.0f, 7));
        GameObject.Find("BGM-Manager").SendMessage("SetLevel", 0);
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneSwitch");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        sceneCount = thisScenesNum;
        GameObject.Find("BGM-Manager").SendMessage("SetLevel", sceneCount);
    }

    void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("scene1-origin");
            sceneCount = 0;
        }else if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("scene2-iceberg");
            sceneCount = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("scene3-elevator");
            sceneCount = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("scene4-volcano");
            sceneCount = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("scene5-planet");
            sceneCount = 4;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("scene6-platform");
            sceneCount = 5;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("scene7-underwater");
            sceneCount = 6;
        }
    }
}
