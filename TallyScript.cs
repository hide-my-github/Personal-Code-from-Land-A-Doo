using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using FacebookLeaderboard;

public class TallyScript : MonoBehaviour {
	
	public static bool levelComplete = false;
	public GameObject scorePopUp;

	Regex rgx = new Regex ("[A]");
	// Use this for initialization
	void Start () {
		//SaveController.control.Save ();
		Debug.Log ("TallyScript.cs");
		if (levelComplete) {
			//score to gold tally section
			int total = 0;

			int replay_divisor = 1;

			if (ObjectivesListScript.replay)
				replay_divisor = 10;
		
			//find what the old BSG was and deduct it
			int deductThis = 0;
			switch (BSG_Script.BSG_Arr [MissionTaskScript.indexStatic]) {
			case 0:
				break;
			case 1:
				deductThis = ObjectivesListScript.bronze / replay_divisor;
				break;
			case 2:
				deductThis = ObjectivesListScript.silver / replay_divisor;
				break;
			case 3:
				deductThis = ObjectivesListScript.gold / replay_divisor;
				break;
			}
			//get the new medal count and add it
			int addThisMuch = 0;
			switch (ScoreChecker.medal) {
			case 0:
				break;
			case 1:
				addThisMuch = ObjectivesListScript.bronze / replay_divisor;
				break;
			case 2:
				addThisMuch = ObjectivesListScript.silver / replay_divisor;
				break;
			case 3:
				addThisMuch = ObjectivesListScript.gold / replay_divisor;
				break;
			}
			total += (addThisMuch - deductThis);
	
			//add gold from score
			int addScore = ScoreScript.score / 100;
			total += addScore;

			//has this stage been played before?
			if (!ObjectivesListScript.replay)
				total += 150;
		
			//add gold for clearing
			total += 100;

			//Debug.Log ("TOTAL GOLD ADDED: " + total);
			PlayerGlobalStuffs.money += total;

//********this is where we update our arrays for BSG and HiScore
			if (HiScoreScript.highScoreArr [MissionTaskScript.indexStatic] < ScoreScript.score) {		//if the past high score is beaten, replace it with the new one
				HiScoreScript.highScoreArr [MissionTaskScript.indexStatic] = ScoreScript.score;
				//PlayerPrefs.SetInt (HiScoreScript.highScoreArr [index].ToString (), ScoreScreen.score);
				//PlayerPrefs.Save ();
			}

			//Debug.Log("EARNED MEDALS: "+ScoreChecker.medal);
			if (BSG_Script.BSG_Arr [MissionTaskScript.indexStatic] < ScoreChecker.medal) {										//if the past medal count is beaten, replace it with the new one
				BSG_Script.BSG_Arr [MissionTaskScript.indexStatic] = ScoreChecker.medal;
			}

			//achievement tally section
			string hits = levelControl.hitString;
			string touch = levelControl.touchString;

			MatchCollection matches = rgx.Matches (hits);

			//red car
			rgx = new Regex ("[A]");
			matches = rgx.Matches (hits);
			StatsScript.redCar += matches.Count;

			//blue car
			rgx = new Regex ("[B]");
			matches = rgx.Matches (hits);
			StatsScript.blueCar += matches.Count;

			//yellow car
			rgx = new Regex ("[V]");
			matches = rgx.Matches (hits);
			StatsScript.yellowCar += matches.Count;

			//red motorcycle
			rgx = new Regex ("[M]");
			matches = rgx.Matches (hits);
			StatsScript.redMotorcycle += matches.Count;

			//purple motorcycle
			rgx = new Regex ("[[P]");
			matches = rgx.Matches (hits);
			StatsScript.purpleMotorcycle += matches.Count;

			//orange motorcycle
			rgx = new Regex ("[O]");
			matches = rgx.Matches (hits);
			StatsScript.orangeMotorcycle += matches.Count;

			//bird
			rgx = new Regex ("[G]");
			matches = rgx.Matches (hits);
			StatsScript.bird += matches.Count;


			//achievements check
			if (StatsScript.bird >= 5 && !PlayerGlobalStuffs.Achievements [0]) {
				PlayerGlobalStuffs.Achievements [0] = true;
				PlayerGlobalStuffs.money += 100;
			}

			if (StatsScript.bird >= 15 && !PlayerGlobalStuffs.Achievements [1]) {
				PlayerGlobalStuffs.Achievements [1] = true;
				PlayerGlobalStuffs.money += 300;
			}

			if (StatsScript.bird >= 50 && !PlayerGlobalStuffs.Achievements [2]) {
				PlayerGlobalStuffs.Achievements [2] = true;
				PlayerGlobalStuffs.money += 1000;
			}

			int totalCars = (StatsScript.blueCar + StatsScript.redCar + StatsScript.yellowCar);
			if (totalCars >= 5 && !PlayerGlobalStuffs.Achievements [3]) {
				PlayerGlobalStuffs.Achievements [3] = true;
				PlayerGlobalStuffs.money += 100;
			}

			if (totalCars >= 15 && !PlayerGlobalStuffs.Achievements [4]) {
				PlayerGlobalStuffs.Achievements [4] = true;
				PlayerGlobalStuffs.money += 300;
			}

			if (totalCars >= 50 && !PlayerGlobalStuffs.Achievements [5]) {
				PlayerGlobalStuffs.Achievements [5] = true;
				PlayerGlobalStuffs.money += 1000;
			}

			int totalMoto = (StatsScript.purpleMotorcycle + StatsScript.orangeMotorcycle + StatsScript.redMotorcycle);
			if (totalMoto >= 3 && !PlayerGlobalStuffs.Achievements [6]) {
				PlayerGlobalStuffs.Achievements [6] = true;
				PlayerGlobalStuffs.money += 100;
			}

			if (totalMoto >= 10 && !PlayerGlobalStuffs.Achievements [7]) {
				PlayerGlobalStuffs.Achievements [7] = true;
				PlayerGlobalStuffs.money += 400;
			}

			if (totalMoto >= 20 && !PlayerGlobalStuffs.Achievements [8]) {
				PlayerGlobalStuffs.Achievements [8] = true;
				PlayerGlobalStuffs.money += 800;
			}
			//First Facebook Login
			if (FBLnIManager.loggedIn == true && !PlayerGlobalStuffs.Achievements [9]){
				PlayerGlobalStuffs.Achievements [9] = true;
				PlayerGlobalStuffs.money += 200;
			}
			//Share a Screenshot
			if (FBLnIManager.sharedScreenshotCounter >= 1 && !PlayerGlobalStuffs.Achievements [10]){
				PlayerGlobalStuffs.Achievements [10] = true;
				PlayerGlobalStuffs.money += 200;
			}
			//5 Friends Accepted Invites
			if (FBLnIManager.acceptedInvitedCounter >= 5 && !PlayerGlobalStuffs.Achievements [11]){
				PlayerGlobalStuffs.Achievements [11] = true;
				PlayerGlobalStuffs.money += 500;
			}
			//Posted a Score
			if (FBLnIManager.postedScoreCounter >= 1 && !PlayerGlobalStuffs.Achievements [12]){
				PlayerGlobalStuffs.Achievements [12] = true;
				PlayerGlobalStuffs.money += 200;
			}
			if (FBLnIManager.friendInvited == true && !PlayerGlobalStuffs.Achievements [13]){
				PlayerGlobalStuffs.Achievements [13] = true;
				PlayerGlobalStuffs.money += 200;
			}
			SaveController.control.Save ();

			GameObject.Find ("_SCRIPTS_").GetComponent<ScoreScreen> ().loadScorePopUp ();
			levelComplete = false;
		} 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
