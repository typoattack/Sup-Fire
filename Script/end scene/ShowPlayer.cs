using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayer : MonoBehaviour {

    ScoreInfo score;
    public GameObject P1;
    public GameObject P2;


    void Start () {

        score = GameObject.Find("ScoreInfo").GetComponent<ScoreInfo>();
        if (score.left >= score.FirstTo)
        {
            P1.SetActive(true);
            P2.SetActive(false);
        }else if(score.right >= score.FirstTo)
        {
            P2.SetActive(true);
            P1.SetActive(false);
        }
    }
	

}
