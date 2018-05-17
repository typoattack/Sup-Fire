using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreInfo : MonoBehaviour {

    public int left;
    public int right;
    public int FirstTo;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Mode(int n)
    {

        FirstTo = n;
    }

    void Start()
    {
        left = 0;
        right = 0;
    }

    void leftPlus()
    {
        left += 1;

        if (left >= FirstTo)
        {
            GameObject.Find("SceneSwitch").SendMessage("End");
        }
        else
        {
            GameObject.Find("SceneSwitch").SendMessage("Switch");
        }
    }

    void rightPlus()
    {
        right += 1;

        if (right >= FirstTo)
        {
            GameObject.Find("SceneSwitch").SendMessage("End");
        }
        else
        {
            GameObject.Find("SceneSwitch").SendMessage("Switch");
        }
    }

    
}
