using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIceFloor : MonoBehaviour {

    public FloeDestroy floe;
    private float StartPoint = -11f;
	
	void Start ()
    {
        SpawnFloor();
	}
	
	void SpawnFloor()
    {
        while (StartPoint <= -3f)
        {
            Vector3 pos = new Vector3(StartPoint, -4.6f, -0.5f);
            FloeDestroy FloorPart = Instantiate(floe, pos, transform.rotation) as FloeDestroy;
            FloorPart.gameObject.SetActive(true);
            StartPoint++;
        }
    }
}
