using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerNPC1 : MonoBehaviour {

    //public float Accelrate;
    //public float MaxSpeed;
    public bool isFireing;
    public bulletMoveNPC bullet;
    public float bulletSize;
    public bool isMissile;
    public MissileMoveNPC missile;
    public Transform firepoint;
    public float bulletSpeed;
    public AudioSource audioS;
    //public AudioSource audioSB;
    //public AudioSource audioR;
    public AudioSource audioM;

    public Animator anim;
    public Animator MoveAnim;

    private float timeBetweenShots;
    private float speedLimiter;

    private Rigidbody rigid;
    private float angle = 0f;
    private int activeTurret = 1;
    private float firingAngle = 45.0f;

    public float startPoint;
    public float motionRange;

    //public float recoil;
    //public float recoilIntensity;
    
    void Start ()
    {
        timeBetweenShots = Random.Range(1.0f, 1.5f);
        speedLimiter = Random.Range(0.5f, 1.5f);
        rigid = this.GetComponent<Rigidbody>();
        if (isMissile == true)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            activeTurret = 3;
            this.firepoint = transform.GetChild(3).GetChild(2).GetComponent<Transform>();
            this.anim = transform.GetChild(3).GetChild(1).GetComponent<Animator>();
            this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
            InvokeRepeating("shootMissile", timeBetweenShots * 5.0f, timeBetweenShots * 5.0f);
            firingAngle = 30f;
        }
        else InvokeRepeating("shoot", 0f, timeBetweenShots);
    }

    void FixedUpdate()
    {
        rigid.position = new Vector3
        (
            startPoint + Mathf.PingPong(Time.time * speedLimiter, motionRange),
            rigid.position.y,
            rigid.position.z
        );
        MoveAnim.Play("body Animation");
        Quaternion rotation = Quaternion.AngleAxis(firingAngle, new Vector3(0f, 0f, -1f));
        transform.GetChild(activeTurret).rotation = rotation;

        //recoil = direction.y < 0f ? new Vector3(0f, 0f, 0f) : recoilIntensity * -direction.normalized;
    }

    void shoot()
    {
        audioS.volume = 0.3f;

        bulletMoveNPC newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as bulletMoveNPC;
        newBullet.gameObject.SetActive(true);
        newBullet.bulletSpeed = Random.Range(bulletSpeed / 2.0f, bulletSpeed);
        newBullet.effectSize = bulletSize / 0.35f;
        newBullet.transform.localScale = new Vector3(bulletSize, 0.1f, bulletSize);
        Animator a = newBullet.GetComponent<Animator>();
        a.enabled = false;
        audioS.pitch = Random.Range(1f, 5f);
        //rigid.AddForce(recoil, ForceMode.Impulse);

        anim.Play("Gun Animation");
        audioS.Play();
    }

    void shootMissile()
    {
        MissileMoveNPC newMissile = Instantiate(missile, firepoint.position, firepoint.rotation) as MissileMoveNPC;
        newMissile.gameObject.SetActive(true);
        newMissile.effectSize = bulletSize / 0.35f;
        newMissile.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
        anim.Play("Missile Launcher Animation");
        audioM.pitch = Random.Range(0.8f, 1.2f);
        audioM.Play();
    }
}
