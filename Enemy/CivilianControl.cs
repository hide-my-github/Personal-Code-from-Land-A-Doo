﻿using UnityEngine;
using System.Collections;

public class CivilianControl : MonoBehaviour {

	//for the enemy speed
	public GameObject CivilianGO;
	public float speed;
	public float maxSpeed;
	private float randomCivilianSpeed;

	// Use this for initialization
	void Start () {
		if (randomCivilianSpeed == 0)
			randomCivilianSpeed = Random.Range(speed, maxSpeed); //speed of car will be randomized
		//else
		//Debug.Log("BIRD SPEED IS AT CONSTANT "+randomBirdSpeed);
		if (CivilianSpawner.angry) {
			CivilianGO.GetComponent<Launcher>().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {

		//enemyGO = GetComponent<Rigidbody2D> ().velocity = (randomSpeed) + new Vector2 (3, 0);
		//Get the enemy current position
		Vector2 position = transform.position;

		//Compute the enemy new position
		position = new Vector2 (position.x - (randomCivilianSpeed * Time.deltaTime), position.y); 

		//Update the enemy position
		transform.position = position;

		//This is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Destroy enemy if goes out of screen
		if ((transform.position.x+5) < min.x) {
			Destroy (gameObject);
		}
	}

	public float getRandSpeed(){
		return randomCivilianSpeed;
	}

	public void setConstantSpeed(float x){
		randomCivilianSpeed = x;
	}
}
