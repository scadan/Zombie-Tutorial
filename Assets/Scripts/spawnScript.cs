using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {

    [SerializeField] GameObject thingToSpawn;
    [SerializeField] float delayBetweenSpawn = 2.0f;
    [SerializeField] float timeOfNextSpawn = 1f;

    int amountToSpawn = 10;
    static int amountSpawned = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time >= timeOfNextSpawn && amountSpawned < amountToSpawn)
        {
            Instantiate(thingToSpawn, transform.position, Quaternion.identity);
            timeOfNextSpawn = Time.time + delayBetweenSpawn;
            amountSpawned++;
        }
		
	}
}
