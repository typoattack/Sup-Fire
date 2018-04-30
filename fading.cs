﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadespeed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadespeed);
    }
    void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }
}