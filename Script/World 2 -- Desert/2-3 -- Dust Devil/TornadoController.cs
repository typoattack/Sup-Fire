using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour {

    public GameObject DustDevil;

    public float waitingForNextSpawn;
    public float theCountdown;
    public Transform tornadoSpawn;

    public float xMin;
    public float xMax;

    private int numberOfTornadoes = 2;
    [HideInInspector] public static int tornadoCount = 0;

    private void Start()
    {
        theCountdown = 5;
    }

    public void Update()
    {
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0 && numberOfTornadoes <= 2)
        {
            SpawnTornadoes();
            theCountdown = waitingForNextSpawn;
        }
    }

    void SpawnTornadoes()
    {
        // Defines the min and max ranges for x and y
        Vector3 pos = new Vector3(Random.Range(xMin, xMax), -2.98f, -0.56f);
        tornadoSpawn.position = pos;

        // Creates the random object at the random 2D position.
        Instantiate(DustDevil, pos, transform.rotation);

        // If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
        //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
        //newgoods.something = somethingelse;
    }
}
