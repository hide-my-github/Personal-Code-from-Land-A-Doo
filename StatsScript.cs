using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsScript : MonoBehaviour {
	public GameObject History;

	public GameObject boxHolder;
	public GameObject box;

	public static int redCar;
	public static int blueCar;
	public static int yellowCar;
	public static int purpleMotorcycle;
	public static int orangeMotorcycle;
	public static int redMotorcycle;
	public static int bird;
	public static int numOfDoos;
	public static int numOfGlides;
	public static float flightTime;
	public static int goldSpent;
	public static int numFlaps;

	// Use this for initialization
	void Start () {

		Text textObject = boxHolder.transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		textObject.text = "Total Flight Time";
		textObject = boxHolder.transform.GetChild (0).GetChild (1).GetComponent<Text> ();
		//need to do hour/minute/second
		int hour = ((int) flightTime)/3600;
		textObject.text = hour.ToString () + ":";
		int minute = (((int)flightTime) % 3600)/ 60;
		textObject.text += minute.ToString () + ":";
		int second = (((int)flightTime) % 3600)% 60;
		textObject.text += second.ToString();

		var newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		var newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Total gold spent";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = goldSpent.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Number of Flaps";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = numFlaps.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Red cars doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = redCar.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Blue cars doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = blueCar.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Yellow cars doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = yellowCar.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Birds doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = bird.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Purple motorcycles doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = purpleMotorcycle.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Orange motorcycles doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = orangeMotorcycle.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Red motorcycles doo'd on";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = redMotorcycle.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Number of total Doos";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = numOfDoos.ToString();

		newBox = Instantiate (box);
		newBox.transform.parent = boxHolder.transform;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		newBoxPosition  = newBox.transform.localPosition;
		newBoxPosition.z = 0.0f;
		newBox.transform.localPosition = newBoxPosition;
		textObject = newBox.transform.GetChild (0).GetComponent<Text> ();
		textObject.text = "Number of total Glides";
		textObject = newBox.transform.GetChild (1).GetComponent<Text> ();
		textObject.text = numOfGlides.ToString();
		/*
		text.text = "Red Cars Doo'd....." + redCar +
					"\nBlue Cars Doo'd....." + blueCar +
					"\nYellow Cars Doo'd....." + yellowCar +
					"\nPurple Motorcycles Doo'd....." + purpleMotorcycle +
					"\nOrange Motorcycles Doo'd....." + orangeMotorcycle +
					"\nRed Motorcycles Doo'd....." + redMotorcycle +
					"\nBirds Doo'd....." + bird +
					"\nNumber of Doos....." + numOfDoos +
					"\nNumber of Glides....." + numOfGlides +
					"\nTotal Flight Time....." + flightTime +
					"\nGold Spent....." + goldSpent;
					*/
	}


	public void SwitchToHistoryTab(){
		History.SetActive (true);
	}

	public void SwitchToAchievementsTab(){
		History.SetActive (false);
	}
}