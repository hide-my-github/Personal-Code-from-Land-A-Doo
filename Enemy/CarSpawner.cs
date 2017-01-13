using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject ViCarGO;
	public GameObject RedCarGO;
	public GameObject BlueCarGO;

	public float maxSpawnRateInSeconds;
	public float top;
	public float bottom;
    public float carSpeed = 0.0f;
	public float minSpawnRate;
	public float maxSpawnRate;
	private bool viCarSpawn = false;
	int viCount;

	// Use this for initialization
	void Start () {
		viCount = 0;
		maxSpawnRateInSeconds = 5f;
		maxSpawnRate = 30f;
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		//Increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawnRate", maxSpawnRate, maxSpawnRate);
	}
	
	// Update is called once per frame
	void Update () {
		//maxSpawnRateInSeconds = maxSpawnRate;
	
	}

	void SpawnEnemy() {
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject anEnemy;

		if (viCarSpawn) {
			float rand = Random.value;
			if (rand <= 0.2) {
				//Debug.Log ("VI CAR");
				anEnemy = (GameObject)Instantiate (ViCarGO);
				viCarSpawn = false;
				viCount++;
				if (viCount >= 3)
					viCarSpawn = true;
			}
			else if (rand > 0.2 && rand <= 0.6)
				anEnemy = (GameObject)Instantiate (RedCarGO);
			else
				anEnemy = (GameObject)Instantiate (BlueCarGO);
		} else {
			if (Random.value > 0.5)
				anEnemy = (GameObject)Instantiate (RedCarGO);
			else
				anEnemy = (GameObject)Instantiate (BlueCarGO);
		}


		anEnemy.GetComponent<EnemyControl>().setConstantSpeed(carSpeed);
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
		carSpeed = x;
    }

	public void setViTrue(){
		viCarSpawn = true;
	}
}
