using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public GameObject collectables;
	float randomXvar, randomYvar;
	Vector2 spawnPosition;

	float spawnRate = 20f;
	float nextSpawn = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawn) {

			nextSpawn = Time.time + spawnRate;
			randomXvar = Random.Range (-6.5f, 6.5f);
			randomYvar = Random.Range (-4f, 4f);
			spawnPosition = new Vector2 (randomXvar, randomYvar);
			Instantiate (collectables, spawnPosition, Quaternion.identity);
		}


	}


}
