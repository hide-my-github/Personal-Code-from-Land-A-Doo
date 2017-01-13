using UnityEngine;
using System.Collections;
//using Mathff;

public class skillSwipe : MonoBehaviour {

	bool oneTouch;
private Vector2 fingerStart;
private Vector2 fingerEnd;
public birdySkillsScript birdSkills;
private CircularSkillFill skill;
	int counter;
	void Start(){
		oneTouch = false;
		skill = GameObject.Find ("SkillCharger").GetComponent<CircularSkillFill> ();
		counter = 0;
	}
	void Update(){
		foreach(Touch touch in Input.touches)
		{
	        if (touch.phase == TouchPhase.Began)
	        {
				if (oneTouch)
					oneTouch = false;
				else
					oneTouch = true;
	            fingerStart = touch.position;
	            fingerEnd  = touch.position;
	        }
	        if (touch.phase == TouchPhase.Moved )
	        {
				fingerEnd = touch.position;
	            //After the checks are performed, set the fingerStart & fingerEnd to be the same
	           // fingerStart = touch.position;   

	        }
	        if(touch.phase == TouchPhase.Ended)
	        {
				if(Mathf.Sqrt(Mathf.Pow((fingerStart.x - fingerEnd.x),2) + Mathf.Pow(Mathf.Abs((fingerStart.y - fingerEnd.y)), 2)) > 80)
	            {
					if (CircularSkillFill.SkillReady && oneTouch) {
						birdSkills.Skill_Current();
						//skill.Reset ();
					}
	            }
	            fingerStart = Vector2.zero;
	            fingerEnd = Vector2.zero;
				oneTouch = false;
	        }
	    }
	}
	//public void tapIncrement(){
	//	tapCount++;
	//}
}
