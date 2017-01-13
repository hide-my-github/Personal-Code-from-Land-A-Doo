using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AchievementsScript : MonoBehaviour {
	public Sprite doneBox;
	public Sprite undoneBox;
	public Sprite uncheckBox;

	public GameObject AchievementParticles;

	public GameObject boxHolder;
	public GameObject box;


	// Use this for initialization
	void Start () {
		Text temp = boxHolder.transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		temp.text = "Land 5 doos on Birds (100G)";
		boxHolder.transform.GetChild (0).name = "100";
		if (PlayerGlobalStuffs.Achievements[0])
			box.GetComponent<Image> ().sprite = doneBox;
		else 
			box.GetComponent<Image> ().sprite = undoneBox;

		var newBox = Instantiate (box);
		newBox.transform.name = "300";
		newBox.transform.SetParent (boxHolder.transform);
		var tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 15 Doos on Birds (300G)";
		if (PlayerGlobalStuffs.Achievements[1])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "1000";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 50 doos on Birds (1000G)";
		if (PlayerGlobalStuffs.Achievements[2])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "100";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 5 doos on Cars (100G)";
		if (PlayerGlobalStuffs.Achievements[3])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "300";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 15 doos on Cars (300G)";
		if (PlayerGlobalStuffs.Achievements[4])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "1000";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 50 doos on Cars (1000G)";
		if (PlayerGlobalStuffs.Achievements[5])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "100";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 3 doos on Motorcycles (100G)";
		if (PlayerGlobalStuffs.Achievements[6])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "400";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 10 doos on Motorcycles (400G)";
		if (PlayerGlobalStuffs.Achievements[7])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "800";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Land 20 doos on Motorcycles (800G)";
		if (PlayerGlobalStuffs.Achievements[8])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "200";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Login to Facebook! (200G)";
		if (PlayerGlobalStuffs.Achievements[9])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "200";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Share a Facebook ScreenShot! (200G)";
		if (PlayerGlobalStuffs.Achievements[10])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "500";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Have a friend on Landadoo! (500G)";
		if (PlayerGlobalStuffs.Achievements[11])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "200";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Post a Score to Facebook! (200G)";
		if (PlayerGlobalStuffs.Achievements[12])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		newBox = Instantiate (box);
		newBox.transform.name = "200";
		newBox.transform.SetParent (boxHolder.transform);
		tempPos  = newBox.transform.localPosition;
		tempPos.z = 0.0f;
		newBox.transform.localPosition = tempPos;
		newBox.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		temp = newBox.transform.GetChild (0).GetComponent<Text> ();
		temp.text = "Invite a friend to play! (200G)";
		if (PlayerGlobalStuffs.Achievements[13])
			newBox.GetComponent<Image> ().sprite = doneBox;
		else
			newBox.GetComponent<Image> ().sprite = undoneBox;

		//scroll through all the boxes and if they're done make them sparkle and clickable
		for (int x = 0; x < 14; x++) {
			if (PlayerGlobalStuffs.Achievements [x]) {
				boxHolder.transform.GetChild(x).GetComponent<Button>().enabled = false;
				//if achievement is done BUT NOT YET ACCEPTED
				if (!PlayerGlobalStuffs.Accepted [x]) {
					boxHolder.transform.GetChild(x).GetComponent<Image>().sprite = uncheckBox;
					boxHolder.transform.GetChild(x).GetComponent<Button>().enabled = true;
				}
			}
		}
	}
	//on click action (need to take off the particle affect and TALLY up the corresponding gold amount
	public void clickAccept(){
		
		//Destroy(EventSystem.current.currentSelectedGameObject.transform.GetChild(1).gameObject);
		GameObject.Find ("CoinFlipParticle").GetComponent<ParticleSystem> ().Play ();

		string name = EventSystem.current.currentSelectedGameObject.name;
		EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().enabled = false;
		EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().sprite = doneBox;
		PlayerGlobalStuffs.money += int.Parse (name);
	}
}