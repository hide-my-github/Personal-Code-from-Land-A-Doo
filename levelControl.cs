using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class levelControl : MonoBehaviour {

	public static levelControl Instance;
	bool knockback = true;
	public bool isComplete = false;
	public bool gameOver = false;

	public GameObject carSpawnerGO;
	public GameObject birdSpawnerGO;
	public GameObject civSpawnerGO;
	public GameObject motorcycleSpawnerGO;
	public GameObject busSpawnerGO;
	public GameObject waterCarSpawnerGO;
	public GameObject scooterSpawnerGO;
	public GameObject robotSpawnerGO;
	public GameObject modernCarSpawnerGO;

	public GameObject windGO;

	public static int currWorld;
	public static int currLevel;

	[SerializeField]
	private GameObject GameOver_Panel;

	private float time;
	private float timeLimit = 120; //2 minutes
	/*
        controlString = "S/S/O/S/X/X"
        need to delimit by "/"
    */
	private string controlString;
	private string[] controlArr = new string[6];

	public static string hitString;
	public static string touchString;

	// Use this for initialization
	void Awake () {

		DontDestroyOnLoad(GameObject.Find("persistentScripts").GetComponent<ObjectivesListScript>());
		hitString = "";
		touchString = "";
		//Debug.Log (sceneName);
		cloudChanger.changer ();
		if (Application.loadedLevelName != "GameplayTutorial") {
			
			controlString = GameObject.Find ("_SCRIPTS_").GetComponent<levelStringScript> ().findString (MissionTaskScript.indexStatic);
			Debug.Log ("Control String: " + controlString);
			controlArr = controlString.Split ('/');
			editCarSpawner (controlArr [0]);
			editBirdSpawner (controlArr [1]);
			editCivSpawner (controlArr [2]);
			editMotorcycleSpawner (controlArr [3]);
			editBusSpawner (controlArr [4]);
			editWaterCarSpawner (controlArr [5]);
			editScooterSpawner (controlArr [6]);
			editRobotSpawner (controlArr [7]);
			editModernCarSpawner (controlArr [8]);
			editWind (controlArr [9]);
			editTime (controlArr [10]);

			currWorld = MissionTaskScript.worldStatic;
			currLevel = MissionTaskScript.levelStatic;
		} else {
			timeLimit = 9999;
		}
	}

	void FixedUpdate(){
		if (timesUp()){
			if (BirdyScript.isAlive) {
				//GameOver_Panel.SetActive(true);

				int index = MissionTaskScript.indexStatic;
				if (HiScoreScript.highScoreArr [index] < ScoreScript.score) {		//if the past high score is beaten, replace it with the new one
					HiScoreScript.highScoreArr [index] = ScoreScript.score;
					//PlayerPrefs.SetInt (HiScoreScript.highScoreArr [index].ToString (), ScoreScreen.score);
					//PlayerPrefs.Save ();
				}
				if (BSG_Script.BSG_Arr [index] < ScoreChecker.medal) {										//if the past medal count is beaten, replace it with the new one
					BSG_Script.BSG_Arr [index] = ScoreChecker.medal;
				}
				isComplete = true;
				Destroy (GameObject.Find ("Birdy").GetComponent<birdySkillsScript> ());
				SceneTransition ();
				//SceneManager.LoadScene("ScoreScreen");

			}
		}
	}

	void editCarSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed
		 * 		V = On; Vi's car has a chance of spawning
		 * 		X = Off
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {                  //speed is constant
			carSpawnerGO.SetActive (true);
		} else if (c == "V") {
			carSpawnerGO.SetActive (true);
			carSpawnerGO.GetComponent<CarSpawner> ().setViTrue ();
		} else if (c != "X") {
			carSpawnerGO.SetActive (true);
			x = float.Parse (c);
			carSpawnerGO.GetComponent<CarSpawner> ().setConstantSpeed (x);
		} 
	}

	void editBirdSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed
		 * 		X = Off
		 * 		A = On; Hostile birds have a chance of pooping
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {						//no birds
			birdSpawnerGO.SetActive (true);
		} else if (c == "A") {
			birdSpawnerGO.SetActive (true);
			birdSpawnerGO.GetComponent<BirdSpawner> ().setAngry ();
		} else if (c != "X") {                  //speed is constant
			x = float.Parse (c);
			birdSpawnerGO.SetActive (true);
			birdSpawnerGO.GetComponent<BirdSpawner> ().setConstantSpeed (x);
		} else
			birdSpawnerGO.SetActive (false);
	}

	void editCivSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; only passive civs
		 * 		X = Off
		 * 		A = On; only hostile civs
		 * 		B = On; both hostile and passive civilians spawn
		 */
		//Debug.Log (c + "/");
		int x = 0;
		if (c == "O") { 									//passive walking pedestrian
			x = 0;
			civSpawnerGO.SetActive (true);
		} else if (c == "A") { 								//angry walking pedestrian
			x = 1;
			civSpawnerGO.SetActive (true);
		} else if (c == "X") { 								//no pedestrian
			//civSpawnerGO.SetActive (false);
		} else {											//both can spawn
			x = 2;
			civSpawnerGO.SetActive (true);
		}

		civSpawnerGO.GetComponent<CivilianSpawner>().setCivMode(x);
	}

	void editMotorcycleSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed
		 * 		X = Off
		 * 		J = On; Josh's Motorcycle possible spawn
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {                  //speed is constant
			motorcycleSpawnerGO.SetActive (true);
		} else if (c == "J") {
			motorcycleSpawnerGO.SetActive (true);
			motorcycleSpawnerGO.GetComponent<MotorcycleSpawner> ().setJoshTrue ();
		} else if (c != "X") {
			motorcycleSpawnerGO.SetActive (true);
			x = float.Parse (c);
			motorcycleSpawnerGO.GetComponent<MotorcycleSpawner> ().setConstantSpeed (x);
		}
	}

	void editBusSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed
		 * 		X = Off
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {
			busSpawnerGO.SetActive (true);
		} else if (c != "X") {
			busSpawnerGO.SetActive (true);
			x = float.Parse (c);
			busSpawnerGO.GetComponent<BusSpawner> ().setConstantSpeed (x);
		} 
	}

	void editWaterCarSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed + hostile
		 * 		X = Off
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {
			waterCarSpawnerGO.SetActive (true);
		} else if (c != "X"){
			waterCarSpawnerGO.SetActive (true);
			x = float.Parse (c);
			waterCarSpawnerGO.GetComponent<WaterCarSpawner> ().setConstantSpeed (x);
		} 
	}

	void editScooterSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed
		 * 		X = Off
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {
			scooterSpawnerGO.SetActive (true);
		} else if (c != "X") {
			x = float.Parse (c);
			scooterSpawnerGO.GetComponent<ScooterSpawner> ().setConstantSpeed (x);
		} 
	}

	void editRobotSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed + hostile
		 * 		X = Off
		 */
		//Debug.Log (c + "/");
		if (c == "O") {
			robotSpawnerGO.SetActive (true);
		}
	}

	void editModernCarSpawner(string c){
		/*
		 * Usage Options: 
		 * 		O = On; random speed
		 * 		X = Off
		 * 		# = On; constant speed
		 */
		//Debug.Log (c + "/");
		float x = 0.0f;
		if (c == "O") {
			modernCarSpawnerGO.SetActive (true);
		} else if (c != "X") {
			modernCarSpawnerGO.SetActive (true);
			x = float.Parse (c);
			modernCarSpawnerGO.GetComponent<ModernCarSpawner> ().setConstantSpeed (x);
		} 
	}

	void editWind(string c){
		/*
		 * Usage Options:	DIRECTION.STRENGTH 
		 * 	DIRECTION OPTIONS:
		 * 		N = North
		 * 		etc.
		 * 
		 * 	STRENGTH OPTIONS:
		 * 		# = Strength
		 * 		0 = Off
		 * 
		 * 	X = Off
		 */
		if (c == "O") {											//IF WIND IS 'O'
			windGO.GetComponent<wind> ().randomWind ();
		} else if (c != "X") {										//if there IS wind
			int tempInt = 8;
			string[] temp = new string[2];
			temp = c.Split ('.');
			//temp[0] should be Cardinality
			switch (temp [0]) {
			case "N":
				tempInt = 0;
				break;
			case "NE":
				tempInt = 1;
				break;
			case "E":
				tempInt = 2;
				break;
			case "SE":
				tempInt = 3;
				break;
			case "S":
				tempInt = 4;
				break;
			case "SW":
				tempInt = 5;
				break;
			case "W":
				tempInt = 6;
				break;
			case "NW":
				tempInt = 7;
				break;
			default:
				Debug.Log ("Something went wrong in switch statement!");
				break;
			}
			//temp[1] should be Strength
			float tempFloat = float.Parse (temp [1]);
			windGO.GetComponent<wind> ().setWind (tempInt, tempFloat);
		} else if (c == "X") {
			windGO.GetComponent<wind> ().setWind (0, 0);
		}

	}

	public int timeLeft(){
		return (int)(timeLimit - time);
	}

	void editTime(string c){
		if (c != "X") {
			timeLimit = float.Parse(c);

			Item item = new Item ();
			if (CharacterPanel.equipSkillItem != null) {
				item = CharacterPanel.equipSkillItem;
			}

			if (item.ID != -1) {
				if (item.Unique == "Time") {
					timeLimit += item.Amount;
				}
			}

			Debug.Log("Time Limit: " + timeLimit);
		}
	}

	bool timesUp(){
		time += Time.deltaTime;
		if (time >= timeLimit)
			return true;
		return false;
	}
	void SceneTransition(){
		Time.timeScale = 1;
		Destroy(GameObject.Find("Button"));
		Destroy (GameObject.Find ("Enemy"));
		//ScoreScript.score += (int)(Mathf.Pow((float)poopSplatter.comboPoint, (float)poopSplatter.comboCounter));
		ScoreScript.score += (int) poopSplatter.comboPoint * poopSplatter.comboCounter;
		poopSplatter.comboCounter = 0;
		poopSplatter.comboPoint = 0;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Scorable");
		foreach(GameObject enemy in enemies){
			if (knockback == true) {
				GameObject.Find ("Birdy").GetComponent<BirdyScript> ().KnockEnemy (enemy);
			}
		}
		knockback = false;
		GameObject.Find("Birdy").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		GameObject.Find ("Birdy").GetComponent<Rigidbody2D> ().velocity = new Vector2 (GameObject.Find ("Birdy").GetComponent<Rigidbody2D> ().velocity.x + .1f, 0.0f);
		if (GameObject.Find("Birdy").transform.position.x > Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 350f, Camera.main.nearClipPlane)).x + 1f) {
			SceneManager.LoadScene ("Cities");
			TallyScript.levelComplete = true;
		}
	}
}