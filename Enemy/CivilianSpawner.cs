using UnityEngine;
using System.Collections;

public class CivilianSpawner : MonoBehaviour {

	public GameObject MaleCivGO;
	public GameObject FemaleCivGO;

	public GameObject ViCivGO;
	public GameObject AshkanCivGO;
	public GameObject JarretCivGO;
	public GameObject JoshCivGO;
	public GameObject LidiaCivGO;
	public GameObject LindaCivGO;
	private GameObject anEnemy;

	float maxSpawnRateInSeconds = 5f;
	public float top;
	public float bottom;
	public float civSpeed = 0.0f;
	public static bool angry = false;
	private bool both = false;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		//Increase spawn rate every 30 seconds
		//InvokeRepeating ("IncreaseSpawnRate", 0f, 10f);

		//InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnEnemy() {
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//GameObject anEnemy;
		int random = Random.Range(1,6); 
		if (both) {
			//randomize angry and passive civs
			int rand = Random.Range(0,2);
			if (rand == 0)
				angry = true;
			else
				angry = false;
		}
		if (!angry) {
			switch (random) {
			case 1: 
				anEnemy = (GameObject)Instantiate (ViCivGO);
				break;
			case 2:
				anEnemy = (GameObject)Instantiate (AshkanCivGO);
				break;
			case 3:
				anEnemy = (GameObject)Instantiate (JarretCivGO);
				break;
			case 4:
				anEnemy = (GameObject)Instantiate (JoshCivGO);
				break;
			case 5:
				anEnemy = (GameObject)Instantiate (LidiaCivGO);
				break;
			case 6:
				anEnemy = (GameObject)Instantiate (LindaCivGO);
				break;
			default:
				break;
			}
		} else {												//SUPPOSED TO BE ANGRY GO'S
			switch (random) {
			case 1: 
				anEnemy = (GameObject)Instantiate (ViCivGO);
				break;
			case 2:
				anEnemy = (GameObject)Instantiate (AshkanCivGO);
				break;
			case 3:
				anEnemy = (GameObject)Instantiate (JarretCivGO);
				break;
			case 4:
				anEnemy = (GameObject)Instantiate (JoshCivGO);
				break;
			case 5:
				anEnemy = (GameObject)Instantiate (LidiaCivGO);
				break;
			case 6:
				anEnemy = (GameObject)Instantiate (LindaCivGO);
				break;
			default:
				break;
			}
		}
			

		anEnemy.GetComponent<CivilianControl>().setConstantSpeed(civSpeed);
		anEnemy.transform.position = new Vector2 (max.x, min.y+top);
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
		civSpeed = x;
	}

	public void setCivMode(int x){
		switch (x) {
		case 0: 						//no angry civs
			angry = false;
			break;
		case 1:							//angry civs
			angry = true;
			break;
		case 2:
			both = true;
			break;
		}
	}
}
