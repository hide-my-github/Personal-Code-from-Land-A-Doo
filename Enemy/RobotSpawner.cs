using UnityEngine;
using System.Collections;

public class RobotSpawner : MonoBehaviour {

	public GameObject robotGO;

	public float maxSpawnRateInSeconds;
	public float top;
	public float bottom;
	public float robotSpeed = 0.0f;
	public float minSpawnRate;
	public float maxSpawnRate;

	// Use this for initialization
	void Start () {
		maxSpawnRateInSeconds = 5f;
		maxSpawnRate = 30f;
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		//Increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawnRate", maxSpawnRate, maxSpawnRate);
	}

	void SpawnEnemy() {
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject anEnemy;

		anEnemy = (GameObject)Instantiate (robotGO);

		anEnemy.GetComponent<RobotControl>().setConstantSpeed(robotSpeed);
		anEnemy.transform.position = new Vector2 (max.x, Random.Range(min.y+top,min.y+bottom));

		ScheduleNextEnemySpawn ();
	}

	void ScheduleNextEnemySpawn() {
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			spawnInSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInSeconds = 1f;
		}
		Invoke ("SpawnEnemy", spawnInSeconds);
	}

	void IncreaseSpawnRate() {
		if (maxSpawnRateInSeconds > 1f) {
			maxSpawnRateInSeconds--;
		}
		if (maxSpawnRateInSeconds == 1f) {
			CancelInvoke ("IncreaseSpawnRate");
		}
	}

	public void setConstantSpeed(float x){
		//Debug.Log ("CARCARCAR");
		robotSpeed = x;
	}
}
