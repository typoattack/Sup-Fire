using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Trigger_star : MonoBehaviour {

    public float cdTime;
    public float countDown;
    public Transform aroundPoint;
    public float angularSpeed;
    public float aroundRadius;
    private float angled;

    private void Start()
    {
        angled = 0;
        transform.position = new Vector3(4f, 0f, -0.56f);
        transform.rotation = Quaternion.Euler(angled, 90, 0);
    }


    void FixedUpdate()
    {


        angled+= (angularSpeed * Time.deltaTime) % 360;
        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);
        float posy = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);
        Vector3 p= new Vector3(posX, posy, 0) + aroundPoint.position;
        transform.position = new Vector3(posX, posy, 0) + aroundPoint.position;
        transform.rotation = Quaternion.Euler(angled, 90, 0);
        
        countDown -= Time.deltaTime;



        if (countDown < 0)
        {
            int childNum;
            countDown = cdTime;
            childNum = Random.Range(0, 3);

            GameObject randomChild = transform.GetChild(childNum).gameObject;
            GameObject newChild = Instantiate(randomChild,p, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
           
            
            newChild.SetActive(true);
            newChild.SendMessage("Setangle", angled);
            //Debug.Log(p);
        }
    }
}
