using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    TextMesh text;
    int left;
    int right;
    GameObject score;

    void Start () {
        text = this.GetComponent<TextMesh>();
        score = GameObject.Find("ScoreInfo");
            left = score.GetComponents<ScoreInfo>()[0].left;
            right = score.GetComponents<ScoreInfo>()[0].right;
            text.text = left.ToString() + "  :  " + right.ToString();
    }

	void FixedUpdate () {
            left = score.GetComponents<ScoreInfo>()[0].left;
            right = score.GetComponents<ScoreInfo>()[0].right;
            text.text = left.ToString() + "  :  " + right.ToString();
    }
}
