using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMove : MonoBehaviour {

    public float StayTime;
    public Animator TitleAnim;

    bool Played = false;

    private void FixedUpdate()
    {
        if (!Played && Time.timeSinceLevelLoad > StayTime)
        {
            
            transform.Translate(0f, 6f, 0f);
            TitleAnim.Play("TitleOut Animation");
            Played = !Played;
        }
    }

}
