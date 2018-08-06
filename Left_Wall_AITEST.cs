using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Wall_AITEST : MonoBehaviour {

    private Rigidbody itself;
    public bool buff_frozen;
    public float WallSpeed;
    public float buff_begin_time;
    public float buff_exist_time;
    private float MoveSpeed;
    // Use this for initialization
    void Start()
    {
        itself = gameObject.GetComponent<Rigidbody>();
    }

    void testbuff()
    {
        if (buff_begin_time != 0)
        {
            if (Time.time - buff_begin_time >= buff_exist_time)
            {
                buff_frozen = false;
                buff_begin_time = 0;
            }
            else
                buff_frozen = true;
        }
    }
    void Buff_Time(float buff_begin)//
    {
        buff_begin_time = buff_begin;


    }

    void GetMovement(float x)
    {
        MoveSpeed = x;
    }

    // Update is called once per frame
    void Update()
    {
        testbuff();

      
        if (buff_frozen)
        {
            MoveSpeed = 0.5f;
        }
        itself.velocity = new Vector3(0, WallSpeed * MoveSpeed, 0);
        
    }
}
