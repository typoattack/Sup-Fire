using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using SharpNeat.Core;
using SharpNeat.Phenomes;
using System; 

[System.Serializable]

public class ControllerP2_neat : UnitController
{
    public Boundary2Stick boundary2stick;

    public float Accelrate;
    public float MaxSpeed;
    public bool isFireing;
    public bulletMove bullet;
    public MissileMove missile;
    public Transform firepoint;
    public float bulletSpeed;
    public AudioSource audioS;
    public AudioSource audioSB;
    public AudioSource audioR;
    public AudioSource audioM;

    public int special;

    public Animator anim;
    public Animator MoveAnim;

    public int maxAmmo;
    public float remainAmmo;
    public GameObject AmmoCount;
    public GameObject LifeCount;
    public GameObject SpeCount;


    public float timeBetweenShots;
    private float shotCounter;
	private bool IsRunning = false;
	private IBlackBox box;

    public bool isBig;
    public bool isMulti;
    public bool isMissile;
    public bool isFrozen;//
    public bool buff_frozen;//
    public float buff_exist_time;//
    public float buff_begin_time;//
    public float buff;//

    public Material ice;//
    public Material normal;//

    public float maxLife;
    public float remainLife;

	private float startTime;
	private float endTime;

    private Rigidbody rigid;

 
    public float recoil;//in angular
    public float recoilIntensity;
    private int updownrecoil;
    private Vector3 left;
    private Vector3 right;

    private GameObject player;
    private bool SetScore = false;

    private Quaternion LastDirection;

    void Buff_Time(float buff_begin)//
    {
        buff_begin_time = buff_begin;
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

    void SetLife(int change)
    {
        remainLife += change;
        if (remainLife > maxLife)
        {
            remainLife = maxLife;
        }
    }

    void Start()
    {
		startTime = Time.time;
		endTime = Time.time;
        rigid = this.GetComponent<Rigidbody>();
        //transform.GetChild(1).transform.Rotate(0f, 90f, 0f);
        LastDirection = new Quaternion(0f, 90f, 0f, 1f);
        float posY = 1 * Mathf.Sin(recoil * Mathf.Deg2Rad);
        float posX = 1 * Mathf.Cos(recoil * Mathf.Deg2Rad);
        left = new Vector3(-posX, -posY, 0f).normalized * recoilIntensity;//-1,0,0 right
        right = new Vector3(posX, posY, 0).normalized * recoilIntensity;//1,0,0 left


    }


    void FixedUpdate()
    {
		if (IsRunning) {
	        rigid.position = new Vector3
	        (
	            Mathf.Clamp(rigid.position.x, boundary2stick.xMin, boundary2stick.xMax),
	            Mathf.Clamp(rigid.position.y, boundary2stick.yMin, boundary2stick.yMax),
	            Mathf.Clamp(rigid.position.z, boundary2stick.zMin, boundary2stick.zMax)
	        );
	        Vector3 pos = rigid.position;

	        Vector3 direction = Vector3.zero;




	        
	        float liftRatio = ((maxLife - 1) / maxLife) * remainLife / maxLife + 1f / maxLife;

	        transform.GetChild(0).transform.localScale = new Vector3(1.5f * liftRatio, 0.3f, 0.5f);

	        LifeCount.SendMessage("SetLife", remainLife);

	        if (remainLife <= 0)
	        {
				endTime = Time.time;
	            StartCoroutine(DelayTime(0.3f));
	            Time.timeScale = 0.2f;
	            Application.targetFrameRate = 150;
	            GameObject[] score = GameObject.FindGameObjectsWithTag("Score");
	            if (!SetScore)
	            {
	                score[0].SendMessage("leftPlus");
	                SetScore = !SetScore;
	            }
	        }
			

			ISignalArray inputArr = box.InputSignalArray;
			inputArr[0] = rigid.position.x;
			inputArr[1] = rigid.position.y;
			inputArr[2] = rigid.position.z;
			inputArr[3] = remainLife;


			box.Activate();

			ISignalArray outputArr = box.OutputSignalArray;

			var neat_movement = (float)outputArr[0];
			var neat_direction = (float)outputArr[1];

			if (neat_movement > 1) {
				neat_movement = 1;
			}

			float h_axis = neat_movement * neat_direction;
			if (h_axis != 0)
			{
				MoveAnim.Play("body Animation");
			}
			testbuff();//
			if (buff_frozen)//
			{
				gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = ice;
				buff = 0.6f;
			}
			else
			{
				gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = normal;
				buff = 1f;
			}

			rigid.velocity = new Vector3(buff * Accelrate * h_axis, rigid.velocity.y, 0f);//


		}

    }

	public override float GetFitness()
	{
		// Implement a meaningful fitness function here, for each unit.
		return endTime - startTime;
	}

	public override void Activate(IBlackBox box)
	{
		print ("here");
		this.box = box;
		this.IsRunning = true;
	}
		
	public override void Stop()
	{
		this.IsRunning = false;
	}

    IEnumerator DelayTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1f;
        Application.targetFrameRate = -1;
        gameObject.SetActive(false);
    }
}

