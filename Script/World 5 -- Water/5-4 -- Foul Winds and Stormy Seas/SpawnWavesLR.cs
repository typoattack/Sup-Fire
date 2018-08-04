using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWavesLR : MonoBehaviour {

    public Waves seaCube;
    public GameObject floor;
    //public Transform CubePos;
    private float StartPoint = -11f;
    private float waveNumber = 0;
    
	void Start ()
    {
        SpawnSeaCubes();
	}
	
    void SpawnSeaCubes()
    {
        while (StartPoint <= 11f)
        {
            Vector3 pos = new Vector3(StartPoint, -10f, floor.transform.position.z);
            //CubePos.position = pos;
            Waves Cube = Instantiate(seaCube, pos, transform.rotation) as Waves;
            Cube.transform.parent = transform;
            Cube.gameObject.SetActive(true);
            Cube.waveNumber = waveNumber;
            StartPoint += 0.2f;
            waveNumber += 1f;
        }
    }
	
}
