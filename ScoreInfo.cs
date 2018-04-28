using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreInfo : MonoBehaviour {

    public int left;
    public int right;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        left = 0;
        right = 0;
    }

    void leftPlus()
    {
        left += 1;
    }

    void rightPlus()
    {
        right += 1;
    }
}
