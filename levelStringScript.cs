using UnityEngine;
using System.Collections;

public class levelStringScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public string findString(int x){
		string temp = "";
		switch (x) {
		//Car/Bird/Civ/Motorcycle/Bus/WaterCar/Scooter/Robot/Modern/Wind/Time
		case 0: //world 1-1
			temp = "V/X/X/X/X/X/X/X/X/X/55";
			break;
		case 1: //world 1-2
			temp = "V/O/X/X/X/X/X/X/X/X/55";
			break;
		case 2: //world 1-3
			temp = "X/O/X/X/O/X/X/X/X/X/55";
			break;
		case 3: //world 1-4
			temp = "V/X/X/J/X/X/X/X/X/X/55";
			break;
		case 4: //world 1-5
			temp = "X/X/B/X/O/X/X/X/X/X/55";
			break;
		case 5: //world 1-6
			temp = "V/O/X/J/X/X/X/X/X/X/55";
			break;
		case 6: //world 1-7
			temp = "X/O/O/J/X/X/X/X/X/X/55";
			break;
		case 7: //world 1-8
			temp = "V/O/A/X/X/X/X/X/X/X/55";
			break;
		//Car/Bird/Civ/Motorcycle/Bus/WaterCar/Scooter/Robot/Modern/Wind/Time
		case 8: //world 2-1
			temp = "X/X/X/J/X/O/X/X/X/X/55";
			break;
		case 9: //world 2-2
			temp = "X/X/A/J/X/O/X/X/X/X/55";
			break;
		case 10: //world 2-3
			temp = "X/X/B/X/X/O/X/X/X/X/55";
			break;
		case 11: //world 2-4
			temp = "X/O/O/X/X/O/X/X/O/X/55";
			break;
		case 12: //world 2-5
			temp = "X/X/X/X/O/O/X/X/X/X/55";
			break;
		case 13: //world 2-6
			temp = "V/X/O/X/X/X/X/X/X/X/55";
			break;
		case 14: //world 2-7
			temp = "V/X/A/X/X/O/X/X/X/X/55";
			break;
		case 15: //world 2-8
			temp = "X/O/A/X/O/O/X/X/X/X/55";
			break;
		//Car/Bird/Civ/Motorcycle/Bus/WaterCar/Scooter/Robot/Modern/Wind/Time
		case 16: //world 3-1
			temp = "V/X/X/X/X/X/O/X/X/X/55";
			break;
		case 17: //world 3-2
			temp = "X/O/X/X/X/O/O/X/X/X/55";
			break;
		case 18: //world 3-3
			temp = "X/X/A/X/O/X/X/X/O/X/55";
			break;
		case 19: //world 3-4
			temp = "V/X/X/J/X/X/O/X/X/X/55";
			break;
		case 20: //world 3-5
			temp = "X/O/X/X/X/O/X/X/X/X/55";
			break;
		case 21: //world 3-6
			temp = "X/X/X/J/O/X/X/X/X/X/55";
			break;
		case 22: //world 3-7
			temp = "X/O/B/X/X/X/X/X/X/X/55";
			break;
		case 23: //world 3-8
			temp = "X/O/X/X/X/O/O/X/O/X/55";
			break;
		//Car/Bird/Civ/Motorcycle/Bus/WaterCar/Scooter/Robot/Modern/Wind/Time
		case 24: //world 4-1
			temp = "X/X/X/X/X/X/X/O/X/X/55";
			break;
		case 25: //world 4-2
			temp = "X/X/X/X/X/X/O/X/O/X/55";
			break;
		case 26: //world 4-3
			temp = "X/X/X/J/X/X/X/O/X/X/55";
			break;
		case 27: //world 4-4
			temp = "X/O/O/X/X/X/X/X/X/X/55";
			break;
		case 28: //world 4-5
			temp = "X/X/X/X/O/X/X/O/X/X/55";
			break;
		case 29: //world 4-6
			temp = "X/X/X/J/X/O/X/X/O/X/55";
			break;
		case 30: //world 4-7
			temp = "X/X/B/X/X/X/O/X/X/X/55";
			break;
		case 31: //world 4-8
			temp = "X/O/A/X/X/X/X/X/X/X/55";
			break;
		}
		return temp;
	}
}
