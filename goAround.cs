using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goAround : MonoBehaviour {

    public float angled;
    public float aroundRadius;
    public float angularSpeed;
    public Transform aroundPoint;
    public Animator MoveAnim;



    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        angled += (angularSpeed * Time.deltaTime) % 360;

        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posy = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);
        transform.position = new Vector3(posX, posy, 0) + aroundPoint.position;
        transform.rotation = Quaternion.Euler(angled, 90, 0);
        MoveAnim.Play("body Animation");
    }
}
