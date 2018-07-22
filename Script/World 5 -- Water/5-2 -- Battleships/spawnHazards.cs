using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHazards : MonoBehaviour
{

    public IcebergMover iceberg;
    public IcebergMover navalMine;
    private IcebergMover target;

    public float waitingForNextSpawn;
    public float theCountdown;
    public Transform targetSpawn;
    private float rand;

    public float xMin;
    public float xMax;

    private void Start()
    {
        theCountdown = 1;
    }

    public void Update()
    {
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnTargets();
            theCountdown = waitingForNextSpawn;
        }
    }

    void SpawnTargets()
    {
        rand = Random.Range(0.0f, 1.0f);
        if (rand < 0.6f) target = iceberg;
        else target = navalMine;

        // Defines the min and max ranges for x and y
        Vector3 pos = new Vector3(Random.Range(xMin, xMax), -5.0f, -1.0f);
        targetSpawn.position = pos;

        // Creates the random object at the random 2D position.
        IcebergMover newObject = Instantiate(target, pos, transform.rotation) as IcebergMover;
        newObject.gameObject.SetActive(true);

        // If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
        //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
        //newgoods.something = somethingelse;
    }
}