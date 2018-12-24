using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloeDestroy : MonoBehaviour {

    public float hp;
    private float startHP;
    private GameObject iceSplatter;
    
	void Start ()
    {
        startHP = hp;
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Missile")
        {
            hp--;
            if (hp < startHP) gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if (hp <= startHP * 0.5f) gameObject.transform.GetChild(2).gameObject.SetActive(true);
            if (hp <= 0)
            {
                iceSplatter = GameObject.Find("FX_IceSplatter");
                GameObject newSplatters = Instantiate(iceSplatter, transform.position, new Quaternion()) as GameObject;
                ParticleSystem SplattersParticle = newSplatters.GetComponent<ParticleSystem>();
                var main = SplattersParticle.main;
                main.startSize = 0.2f;
                main.startSpeed = 5f;
                Destroy(newSplatters, 1.5f);
                Destroy(gameObject);
            }
        }
    }
}
