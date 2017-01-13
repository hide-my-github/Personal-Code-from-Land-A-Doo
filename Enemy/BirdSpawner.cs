using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {

	public GameObject BirdGO;
	float maxSpawnRateInSeconds = 6f;
	public float top;
	public float bottom; 
	public float birdSpeed = 0.0f;
	private int birdNum;
	int currLevel;
	int currWorld;
	public static bool angry = false;

	// Use this for initialization
	void Start () 
	{
		Invoke ("SpawnBird", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 seconds

		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);

		currWorld = levelControl.currWorld;
		currLevel = levelControl.currLevel;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void setAngry() {
		angry = true;
	}

	void SpawnBird() 
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		birdNum++;
		Debug.Log ("Total Bird: " + birdNum);
		//   Debug.Log("!!!!!!!!!!!!!----------------!!!!!!!!!!!!");
		//  Debug.Log("Min.x = " + min.x + " Min.y = " + min.y);
		//  Debug.Log("Max.x = " + max.x + " Max.y = " + max.y);

		GameObject anEnemy = Instantiate (BirdGO);
		anEnemy.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		anEnemy.transform.position = new Vector2 (max.x, Random.Range(min.y+top,min.y+bottom));

		if (Random.Range(1, 101)  > 17) //13
			ScheduleNextBirdSpawn();
		else
			ScheduleNextBirdFlockSpawn();
	}

	void SpawnBirdFlock()
	{
		if (currWorld == 1)
		{
			formationSpawnerLevel_01();
		}

		else if (currWorld == 2)
		{
			int formationType = Random.Range(1, 5);
			switch (formationType)
			{
			case 1:
				formationSpawnerLevel_01();
				break;

			default:
				formationSpawnerLevel_02();
				break;

			}
		}


		else if (currWorld == 3)
		{
			if (currLevel < 8)
			{
				int formationType2 = Random.Range(1, 11);
				switch (formationType2)
				{
				case 1:
					formationSpawnerLevel_01();
					break;

				case 2:
					formationSpawnerLevel_02();
					break;

				default:
					formationSpawnerLevel_03();
					break;
				}
			}

			else
			{
				int formationType3 = Random.Range(1, 13);
				switch (formationType3)
				{
				case 1:
					formationSpawnerLevel_01();
					break;

				case 2:
					formationSpawnerLevel_02();
					break;

				case 3:
				case 4:
					formationSpawnerLevel_03();
					break;

				default:
					formationSpawnerLevel_04();
					break;
				}
			}

		}

		else if (currWorld == 4)
		{
			int formationType4 = Random.Range(1, 17);
			switch (formationType4)
			{
			case 1:
				formationSpawnerLevel_01();
				break;

			case 2:
				formationSpawnerLevel_02();
				break;

			case 3:
			case 4:
				formationSpawnerLevel_03();
				break;

			default:
				formationSpawnerLevel_04();
				break;
			}
		}




		if (Random.Range(1, 101) > 10)  // > 10
			ScheduleNextBirdSpawn();
		else
			ScheduleNextBirdFlockSpawn();
	}

	/// <summary>
	/// Updated Formations and Level Progression
	/// </summary>
	/// 
	void formationSpawnerLevel_04()
	{
		int formationType = Random.Range(1, 6);
		switch (formationType)
		{
		case 1:
			formationSixTunnel();
			break;

		case 2:
			formationEightVerticalOblique();
			break;

		case 3:
			formationNineTrap();
			break;

		case 4:
			formationTenTrapDive();
			break;

		case 5:
			formationTenTrapFlap();
			break;

		default:
			break;
		}
	}
	void formationSpawnerLevel_03()
	{
		int formationType = Random.Range(1, 7);
		switch (formationType)
		{
		case 1:
			formationFourVerticalObliqueDown();
			break;

		case 2:
			formationFourVerticalObliqueUp();
			break;

		case 3:
			flockSeven();
			break;

		case 4:
			flockEight();
			break;

		case 5:
			flockNine();
			break;

		case 6:
			flockTen();
			break;

		default:
			break;
		}
	}
	void formationSpawnerLevel_02()
	{
		int formationType = Random.Range(1, 6);
		switch (formationType)
		{
		case 1:
			formationFourVertical();
			break;

		case 2:
			flockTwo();
			break;

		case 3:
			flockFive();
			break;

		case 4:
			flockFour();
			break;

		case 5:
			flockSix();
			break;

		default:
			break;
		}
	}
	void formationSpawnerLevel_01()
	{
		int formationType = Random.Range(1, 4);
		switch (formationType)
		{
		case 1:
			formationFourHorizontal();
			break;

		case 2:
			flockThree();
			break;

		case 3:
			flockOne();
			break;

		default:
			break;
		}
	}
	void flockEleven()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);
		GameObject enemy9 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy9.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom+3);
		enemy1.transform.position = new Vector2(max.x+2.25f, yPos);
		enemy2.transform.position = new Vector2(max.x + .75f + 2.25f, yPos - 1);
		enemy3.transform.position = new Vector2(max.x - .75f + 2.25f, yPos - 1);
		enemy4.transform.position = new Vector2(max.x + 1.5f + 2.25f, yPos - 2);
		enemy5.transform.position = new Vector2(max.x - 1.5f + 2.25f, yPos - 2);
		enemy6.transform.position = new Vector2(max.x + 2.25f + 2.25f, yPos - 3);
		enemy7.transform.position = new Vector2(max.x - 2.25f + 2.25f, yPos - 3);
		enemy8.transform.position = new Vector2(max.x + .75f + 2.25f, yPos - 3);
		enemy9.transform.position = new Vector2(max.x - .75f + 2.25f, yPos - 3);
		//enemy8.transform.position = new Vector2(max.x + 6, yPos);

	}
	void flockTen()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);
		GameObject enemy9 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy9.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top - 2, min.y + bottom + 2f);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x+1.5f, yPos - 1);
		enemy3.transform.position = new Vector2(max.x+1.5f, yPos + 1);
		enemy4.transform.position = new Vector2(max.x+3, yPos - 2);
		enemy5.transform.position = new Vector2(max.x+3, yPos + 2);
		enemy6.transform.position = new Vector2(max.x+4.5f, yPos - 1);
		enemy7.transform.position = new Vector2(max.x+4.5f, yPos + 1);
		enemy8.transform.position = new Vector2(max.x+6, yPos);

	}
	void flockNine()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);
		GameObject enemy9 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy9.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 4f);
		enemy1.transform.position = new Vector2(max.x, yPos - 2);
		enemy2.transform.position = new Vector2(max.x + 1.5f, yPos - 2);
		enemy3.transform.position = new Vector2(max.x + 3f, yPos - 2);
		enemy4.transform.position = new Vector2(max.x + .75f, yPos - 1f);
		enemy5.transform.position = new Vector2(max.x + 2.25f, yPos - 1);
		enemy6.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy7.transform.position = new Vector2(max.x + .75f, yPos - 3f);
		enemy8.transform.position = new Vector2(max.x + 2.25f, yPos - 3);
		enemy9.transform.position = new Vector2(max.x + 1.5f, yPos - 4);
	}
	void flockEight()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);


		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 5f);
		enemy1.transform.position = new Vector2(max.x + .75f, yPos);
		enemy2.transform.position = new Vector2(max.x + 2.25f, yPos);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos - 1f);

		enemy4.transform.position = new Vector2(max.x + 1.5f, yPos - 2f);
		enemy5.transform.position = new Vector2(max.x + .75f, yPos - 3f);
		enemy6.transform.position = new Vector2(max.x + 2.25f, yPos - 3f);
	}
	void flockSeven()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);


		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 5f);
		enemy1.transform.position = new Vector2(max.x + .75f, yPos);
		enemy2.transform.position = new Vector2(max.x + 2.25f, yPos);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos - 1f);

		enemy4.transform.position = new Vector2(max.x + 1.5f, yPos - 4f);
		enemy5.transform.position = new Vector2(max.x + .75f, yPos - 5f);
		enemy6.transform.position = new Vector2(max.x + 2.25f,yPos - 5f);

	}
	void flockSix()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 2f);
		enemy1.transform.position = new Vector2(max.x, yPos - 2);
		enemy2.transform.position = new Vector2(max.x + 1.5f, yPos - 2);
		enemy3.transform.position = new Vector2(max.x + 3f, yPos - 2);
		enemy4.transform.position = new Vector2(max.x + .75f, yPos - 1f);
		enemy5.transform.position = new Vector2(max.x + 2.25f, yPos - 1);
		enemy6.transform.position = new Vector2(max.x + 1.5f, yPos);

	}
	void flockFive()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 2f);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy3.transform.position = new Vector2(max.x + 3f, yPos);
		enemy4.transform.position = new Vector2(max.x + .75f, yPos - 1f);
		enemy5.transform.position = new Vector2(max.x + 2.25f, yPos - 1);
		enemy6.transform.position = new Vector2(max.x + 1.5f, yPos - 2f);

	}
	void flockFour()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 2f);
		enemy1.transform.position = new Vector2(max.x + 1.5f, yPos - 0.5f);
		enemy2.transform.position = new Vector2(max.x, yPos - 1f);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos - 1.5f);
		enemy4.transform.position = new Vector2(max.x + 3f, yPos - 1f);
		enemy5.transform.position = new Vector2(max.x + 3f, yPos);
		enemy6.transform.position = new Vector2(max.x + 3f, yPos - 2f);


	}
	void flockThree()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top, min.y + bottom + 1f);
		enemy1.transform.position = new Vector2(max.x + 1f, yPos);
		enemy2.transform.position = new Vector2(max.x, yPos - 0.5f);
		enemy3.transform.position = new Vector2(max.x + 1f, yPos - 1f);

	}
	void flockTwo()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);


		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 2);
		enemy1.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy2.transform.position = new Vector2(max.x + 1.5f, yPos - 1f);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos - 2);
		enemy4.transform.position = new Vector2(max.x, yPos - 1f);
		enemy5.transform.position = new Vector2(max.x + 3, yPos - 1f);

	}
	void flockOne()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top, min.y + bottom + 1);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x, yPos - 1f);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy4.transform.position = new Vector2(max.x + 1.5f, yPos - 1f);

	}




	//End of
	//Updated Formations and Level Progression



	private void ScheduleNextBirdFlockSpawn()
	{
		float spawnInSeconds; //= Random.Range(1f, 6f);

		if (maxSpawnRateInSeconds > 1f) {
			spawnInSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInSeconds = 1f;
		}

		Invoke("SpawnBirdFlock", spawnInSeconds);
	}

	void ScheduleNextBirdSpawn() {
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			//spawnInSeconds = .5f;
			spawnInSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else {
			spawnInSeconds = 1f;
		}
		Invoke ("SpawnBird", spawnInSeconds);
		//Invoke("SpawnBirdFlock", spawnInSeconds);
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
		//Debug.Log ("BIRDBIRDBIRD");
		birdSpeed = x;
	}

	void formationNineTrap()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);
		GameObject enemy9 = Instantiate(BirdGO);




		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy9.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);



		float yPos = Random.Range(min.y + top, min.y + bottom + 3);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x, yPos - 3f);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy4.transform.position = new Vector2(max.x + 1.5f, yPos - 3f);
		enemy5.transform.position = new Vector2(max.x + 3, yPos);
		enemy6.transform.position = new Vector2(max.x + 3, yPos - 3f);

		enemy7.transform.position = new Vector2(max.x + 5, yPos - 1.5f);
		enemy8.transform.position = new Vector2(max.x + 6.5f, yPos - 3f);
		enemy9.transform.position = new Vector2(max.x + 6.5f, yPos);





	}

	void formationTenTrapDive()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);
		GameObject enemy9 = Instantiate(BirdGO);
		GameObject enemy10 = Instantiate(BirdGO);





		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy9.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy10.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);




		float yPos = Random.Range(min.y + top, min.y + bottom + 3);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x, yPos - 3f);
		enemy3.transform.position = new Vector2(max.x + 2f, yPos);
		enemy4.transform.position = new Vector2(max.x + 2f, yPos - 3f);
		enemy5.transform.position = new Vector2(max.x + 4, yPos);
		enemy6.transform.position = new Vector2(max.x + 4, yPos - 3f);

		enemy7.transform.position = new Vector2(max.x + 6, yPos);
		enemy8.transform.position = new Vector2(max.x + 7.5f, yPos - 1f);
		enemy9.transform.position = new Vector2(max.x + 9f, yPos - 2f);
		enemy10.transform.position = new Vector2(max.x + 10.5f, yPos - 3f);



	}

	void formationTenTrapFlap()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);
		GameObject enemy9 = Instantiate(BirdGO);
		GameObject enemy10 = Instantiate(BirdGO);




		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy9.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy10.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);




		float yPos = Random.Range(min.y + top - 2, min.y + bottom + 3);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x, yPos - 3f);
		enemy3.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy4.transform.position = new Vector2(max.x + 1.5f, yPos - 3f);
		enemy5.transform.position = new Vector2(max.x + 3, yPos);
		enemy6.transform.position = new Vector2(max.x + 3, yPos - 3f);

		enemy7.transform.position = new Vector2(max.x + 6, yPos - 3);
		enemy8.transform.position = new Vector2(max.x + 7.5f, yPos - 2f);
		enemy9.transform.position = new Vector2(max.x + 9f, yPos - 1);
		enemy10.transform.position = new Vector2(max.x + 10.5f, yPos);






	}

	void formationSixTunnel()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);
		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);



		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);


		float yPos = Random.Range(min.y + top, min.y + bottom + 2.5f);
		enemy1.transform.position = new Vector2(max.x, yPos );
		enemy2.transform.position = new Vector2(max.x + 1.5f, yPos - 2.5f);
		enemy3.transform.position = new Vector2(max.x + 3, yPos);
		enemy4.transform.position = new Vector2(max.x + 4.5f, yPos - 2.5f);
		enemy5.transform.position = new Vector2(max.x + 6, yPos);
		enemy6.transform.position = new Vector2(max.x + 7.5f, yPos - 2.5f);



	}

	void formationEightVerticalOblique()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);

		GameObject enemy5 = Instantiate(BirdGO);
		GameObject enemy6 = Instantiate(BirdGO);
		GameObject enemy7 = Instantiate(BirdGO);
		GameObject enemy8 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		enemy5.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy6.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy7.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy8.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top, min.y + bottom + 3);
		enemy1.transform.position = new Vector2(max.x, yPos - 3);
		enemy2.transform.position = new Vector2(max.x + 1, yPos - 2);
		enemy3.transform.position = new Vector2(max.x + 2, yPos - 1);
		enemy4.transform.position = new Vector2(max.x + 3, yPos);

		enemy5.transform.position = new Vector2(max.x + 5, yPos);
		enemy6.transform.position = new Vector2(max.x + 6, yPos - 1);
		enemy7.transform.position = new Vector2(max.x + 7, yPos - 2);
		enemy8.transform.position = new Vector2(max.x + 8, yPos - 3);

	}

	void formationFourVertical()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top - 2, min.y + bottom + 1);
		enemy1.transform.position = new Vector2(max.x, yPos + 1);
		enemy2.transform.position = new Vector2(max.x, yPos + 2);
		enemy3.transform.position = new Vector2(max.x, yPos - 1);
		enemy4.transform.position = new Vector2(max.x, yPos);

	}


	void formationFourVerticalObliqueDown()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top, min.y + bottom + 3);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x + 1, yPos - 1);
		enemy3.transform.position = new Vector2(max.x + 2, yPos - 2);
		enemy4.transform.position = new Vector2(max.x + 3, yPos - 3);

	}

	void formationFourVerticalObliqueUp()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top, min.y + bottom + 3);
		enemy1.transform.position = new Vector2(max.x, yPos - 3);
		enemy2.transform.position = new Vector2(max.x + 1, yPos - 2);
		enemy3.transform.position = new Vector2(max.x + 2, yPos - 1);
		enemy4.transform.position = new Vector2(max.x + 3, yPos);

	}


	void formationFourHorizontal()
	{
		//this is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//this is the top-right of screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// float speed;
		// speed.setConstantSpeed(birdSpeed);
		GameObject enemy1 = Instantiate(BirdGO);
		GameObject enemy2 = Instantiate(BirdGO);
		GameObject enemy3 = Instantiate(BirdGO);
		GameObject enemy4 = Instantiate(BirdGO);

		// enemy1.GetComponent<BirdControl
		enemy1.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy2.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy3.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);
		enemy4.GetComponent<BirdControl>().setConstantSpeed(birdSpeed);

		float yPos = Random.Range(min.y + top, min.y + bottom);
		enemy1.transform.position = new Vector2(max.x, yPos);
		enemy2.transform.position = new Vector2(max.x + 1.5f, yPos);
		enemy3.transform.position = new Vector2(max.x + 3, yPos);
		enemy4.transform.position = new Vector2(max.x + 4.5f, yPos);

	}





}