using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

[System.Serializable]
public class Boundary1Mouse_L8
{
    public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class controllerP1_L8 : MonoBehaviour
{
    public Boundary1Mouse_L8 boundary1mouse;

    public float Accelrate;
    public float MaxSpeed;
    public bool isFireing;
    public bulletMove_L8 bullet;
    public MissileMove_L8 missile;
    public Transform firepoint;
    public float bulletSpeed;
    public AudioSource audioS;
    public AudioSource audioSB;
    public AudioSource audioR;
    public AudioSource audioM;
    private float wind;

    private bool isGrounded;
    private float h_axis;

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


    private Rigidbody rigid;
    private float angle = 0f;
    private int activeTurret = 1;

    public float recoil;
    public float recoilIntensity;
    private int updownrecoil;
    private Vector3 up;
    private Vector3 down;

    private GameObject player;
    private bool SetScore = false;

    private Quaternion LastDirection;
    private bool isSpecial = false;
    public int recoilRange = 45;
    public float windForce = 5.0f;

    void SetBig()
    {
        ResetBarrel();//fix bug
        isBig = true;
        isMulti = false;
        isMissile = false;
        isFrozen = false;//
        audioR.Play();
        special = 5;
        isSpecial = true;
        UseTurret1();
        gameObject.transform.GetChild(1).transform.localScale = new Vector3(0.5f, 0.5f, 0.3f);
        this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    void SetMulti()
    {
        ResetBarrel();//fix bug
        isBig = false;
        isMulti = true;
        isMissile = false;
        isFrozen = false;//
        audioR.Play();
        special = 5;
        isSpecial = true;
        gameObject.transform.GetChild(1).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        UseTurret2();
    }

    void SetFrozen()//
    {
        ResetBarrel();
        isBig = false;
        isMulti = false;
        isMissile = false;
        isFrozen = true;//
        audioR.Play();
        special = 5;
        isSpecial = true;
        gameObject.transform.GetChild(1).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
        UseTurret1();

    }

    void SetMissile()
    {
        ResetBarrel();
        isBig = false;
        isMulti = false;
        isMissile = true;
        isFrozen = false;//
        audioR.Play();
        special = 3;
        isSpecial = true;
        gameObject.transform.GetChild(1).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        UseTurret3();
    }

    //fix bug
    void ResetBarrel() {
        if (isMulti) gameObject.transform.GetChild(2).GetChild(1).transform.localScale = new Vector3(1f, 1f, 1f);
        else if (isMissile) gameObject.transform.GetChild(3).GetChild(1).transform.localScale = new Vector3(1f, 1f, 1f);
        else gameObject.transform.GetChild(1).GetChild(1).transform.localScale = new Vector3(1f, 1f, 1f);
    }
    //

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

    void SetAmmo(float change)
    {

        remainAmmo += change;

        
        if (remainAmmo > maxAmmo)
        {
            remainAmmo = maxAmmo;
        }
    }

    private void UseTurret1()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        activeTurret = 1;
        this.firepoint = transform.GetChild(1).GetChild(2).GetComponent<Transform>();
        this.SpeCount = transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
        this.anim = transform.GetChild(1).GetChild(1).GetComponent<Animator>();
    }

    private void UseTurret2()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        activeTurret = 2;
        this.firepoint = transform.GetChild(2).GetChild(2).GetComponent<Transform>();
        this.SpeCount = transform.GetChild(2).GetChild(1).GetChild(2).gameObject;
        this.anim = transform.GetChild(2).GetChild(1).GetComponent<Animator>();
        this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    private void UseTurret3()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        activeTurret = 3;
        this.firepoint = transform.GetChild(3).GetChild(2).GetComponent<Transform>();
        this.SpeCount = transform.GetChild(3).GetChild(1).GetChild(1).gameObject;
        this.anim = transform.GetChild(3).GetChild(1).GetComponent<Animator>();
        this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    void recoiltest()
    {
        float angled = transform.GetChild(activeTurret).localRotation.eulerAngles.z;
        if (angled >= 90 - recoilRange && angled <= 90 + recoilRange)
            updownrecoil = 1;
        else if (angled >= 270 - recoilRange && angled <= 270 + recoilRange)
            updownrecoil = 0;
        else
            updownrecoil = 2;
    }

    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        wind = WindController.wind;
    }


    void FixedUpdate()
    {
        //set recoil angle
        recoil = 360 - transform.localRotation.eulerAngles.x;
        float posY = 1 * Mathf.Sin(recoil * Mathf.Deg2Rad);
        float posX = 1 * Mathf.Cos(recoil * Mathf.Deg2Rad);
        up = new Vector3(-posX, -posY, 0f).normalized * recoilIntensity;
        down = new Vector3(posX, posY, 0).normalized * recoilIntensity;

        wind = WindController.wind;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rigid.position = new Vector3
        (
            Mathf.Clamp(rigid.position.x, boundary1mouse.xMin, boundary1mouse.xMax),
            Mathf.Clamp(rigid.position.y, boundary1mouse.yMin, boundary1mouse.yMax),
            Mathf.Clamp(rigid.position.z, boundary1mouse.zMin, boundary1mouse.zMax)
        );
        Vector3 pos = rigid.position;
        Vector3 direction = mousePos - pos;
        recoiltest();
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, -1f));
        transform.GetChild(activeTurret).rotation = rotation;

        if(isGrounded == true) h_axis = Input.GetAxis("Horizontal");
        else h_axis = 0;

        testbuff();
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
        rigid.velocity = new Vector3(buff * Accelrate * h_axis, rigid.velocity.y, 0f);
        rigid.AddForce(Vector3.right * wind * 100);
        if (h_axis != 0)
        {
            MoveAnim.Play("body Animation");
        }

        if ((Input.GetMouseButton(0)|| Input.GetKey(KeyCode.Space)) && remainAmmo >= 1) //fire
        {
            isFireing = true;
        }
        else
        {
            isFireing = false;
        }

        if (isFireing)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                audioS.volume = 0.3f;

                if (isMulti)
                {
                    special -= 1;
                    bulletMove_L8 newBullet1 = Instantiate(bullet, firepoint.position, firepoint.rotation) as bulletMove_L8;
                    bulletMove_L8 newBullet2 = Instantiate(bullet, firepoint.position, firepoint.rotation) as bulletMove_L8;

                    newBullet1.gameObject.SetActive(true);
                    newBullet1.transform.Translate(new Vector3(0.2f, 0f, 0f));
                    newBullet1.transform.Rotate(new Vector3(0f, 0f, -5f));
                    newBullet1.bulletSpeed = bulletSpeed;
                    newBullet1.SendMessage("SetMulti", true);

                    newBullet2.gameObject.SetActive(true);
                    newBullet2.transform.Translate(new Vector3(-0.2f, 0f, 0f));
                    newBullet2.transform.Rotate(new Vector3(0f, 0f, 5f));
                    newBullet2.bulletSpeed = bulletSpeed;
                    newBullet2.SendMessage("SetMulti", true);

                    //CameraShaker.Instance.ShakeOnce(1.5f, 4f, 0f, 1.5f);
                    if (updownrecoil == 0)
                        rigid.AddForce(1.5f * up, ForceMode.Impulse);
                    else if (updownrecoil == 1)
                        rigid.AddForce(1.5f * down, ForceMode.Impulse);
                    audioS.pitch = Random.Range(1f, 5f);
                    anim.Play("Double gun Animation");
                }
                else
                {   

                    if (isMissile)
                    {
                        special -= 1;
                        MissileMove_L8 newMissile = Instantiate(missile, firepoint.position, firepoint.rotation) as MissileMove_L8;
                        newMissile.gameObject.SetActive(true);
                        //CameraShaker.Instance.ShakeOnce(2f, 4f, 0f, 1.5f);
                        anim.Play("Missile Launcher Animation");
                    }
                    else
                    {
                        bulletMove_L8 newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as bulletMove_L8;
                        newBullet.gameObject.SetActive(true);
                        newBullet.bulletSpeed = bulletSpeed;
                        if (isBig)
                        {
                            audioSB.pitch = Random.Range(0.2f, 0.3f);
                            audioSB.volume = 1.0f;
                            special -= 1;
                            newBullet.transform.localScale = new Vector3(1f, 0.1f, 1f);
                            Animator a = newBullet.GetComponent<Animator>();
 //                           ParticleSystem p = newBullet.GetComponent<ParticleSystem>();
                            a.enabled = false;
                            newBullet.SendMessage("SetBig", true);
                            //CameraShaker.Instance.ShakeOnce(2.5f, 4f, 0f, 3f);
                            if (updownrecoil == 0)
                                rigid.AddForce(2 * up, ForceMode.Impulse);
                            else if (updownrecoil == 1)
                                rigid.AddForce(2 * down, ForceMode.Impulse);

                        }
                        else if (isFrozen)//
                        {
                            special -= 1;
                            newBullet.SendMessage("SetFrozen", true);
                            newBullet.transform.GetChild(0).gameObject.SetActive(true);
                            newBullet.GetComponent<ParticleSystemRenderer>().material = ice;
                            //CameraShaker.Instance.ShakeOnce(1.25f, 4f, 0f, 1.5f);
                            if (updownrecoil == 0)
                                rigid.AddForce(up, ForceMode.Impulse);
                            else if (updownrecoil == 1)
                                rigid.AddForce(down, ForceMode.Impulse);
                            audioS.pitch = Random.Range(1f, 5f);
                        }
                        else
                        {
                            //CameraShaker.Instance.ShakeOnce(1.25f, 4f, 0f, 1.5f);
                            audioS.pitch = Random.Range(1f, 5f);
                            if (updownrecoil == 0)
                                rigid.AddForce(up, ForceMode.Impulse);
                            else if (updownrecoil == 1)
                                rigid.AddForce(down, ForceMode.Impulse);

                        }
                        anim.Play("Gun Animation");                    
                    }
                }

                SetAmmo(-1);
                if (!isMissile)
                {
                    if (isBig)
                    {
                        audioSB.Play();
                    }
                    else
                    {
                        audioS.Play();
                    }
                }
                else {
                    audioM.pitch = Random.Range(0.8f, 1.2f);
                    audioM.Play();
                }
            }
        }
        else
        {
            //shotCounter = 0;
            shotCounter -= Time.deltaTime;

        }
        AmmoCount.SendMessage("SetAmmo", Mathf.Floor(remainAmmo));

        float liftRatio = ((maxLife - 1) / maxLife) * remainLife / maxLife + 1f/ maxLife;

        transform.GetChild(0).transform.localScale = new Vector3(1.5f * liftRatio, 0.3f, 0.5f);

        LifeCount.SendMessage("SetLife", remainLife);

        if(remainLife <= 0)
        {
            StartCoroutine(DelayTime(0.3f));
            Time.timeScale = 0.2f;
            GameObject[] score = GameObject.FindGameObjectsWithTag("Score");
            if (!SetScore)
            {
                score[0].SendMessage("rightPlus");
                SetScore = !SetScore;
            }

        }

        if (isSpecial && special <= 0)
        {
            isBig = false;
            isMulti = false;
            isMissile = false;
            isFrozen = false;//
            gameObject.transform.GetChild(1).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
            UseTurret1();
            isSpecial = !isSpecial;
        }

        SpeCount.SendMessage("SetSpe", special);
    }

    IEnumerator DelayTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tornado")
            rigid.AddForce(new Vector3(0f, windForce, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "water")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "water")
            isGrounded = false;
    }
}
