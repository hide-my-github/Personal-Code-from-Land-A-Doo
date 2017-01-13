using UnityEngine;
using System.Collections;

public class MotorcycleSpawner: MonoBehaviour {

	public GameObject JoshMotoGO;
	public GameObject PurpleMotoGO;
	public GameObject OrangeMotoGO;
	public float maxSpawnRateInSeconds = 5f;
	public float top;
	public float bottom;
	public float motoSpeed = 0.0f;

	private bool joshMotoSpawn = false;
	int joshCount;

	// Use this for initialization
	void Start () {
		joshCount = 0;
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 seconds

		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnEnemy() {
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject anEnemy = (GameObject)Instantiate (OrangeMotoGO);			//oj by default
		if (Random.value > 0.5)
			anEnemy = (GameObject)Instantiate (OrangeMotoGO);
		else
			anEnemy = (GameObject)Instantiate (PurpleMotoGO);

		if (joshMotoSpawn) {
			if (Random.value <= 0.1) {
				anEnemy = (GameObject)Instantiate (JoshMotoGO);
				joshMotoSpawn = false;
				joshCount++;
				if (joshCount <= 3)
					joshMotoSpawn = true;
			}
		}


		anEnemy.GetComponent<MotorcycleControl>().setConstantSpeed(motoSpeed);
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
		motoSpeed = x;
	}

	public void setJoshTrue(){
		joshMotoSpawn = true;
	}
}
