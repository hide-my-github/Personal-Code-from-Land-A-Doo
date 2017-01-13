using UnityEngine;
using System.Collections;

public class TutorialBirdScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {

		//enemyGO = GetComponent<Rigidbody2D> ().velocity = (randomSpeed) + new Vector2 (3, 0);
		//Get the enemy current position
		Vector2 position = transform.position;

		//Compute the enemy new position
		position = new Vector2 (position.x + (CameraManager.speed * Time.deltaTime), position.y); 

		//Update the enemy position
		transform.position = position;

		//This is the bottom-left of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Destroy enemy if goes out of screen
		if ((transform.position.x+5) < min.x) {
			Destroy (gameObject);
		}
	}
}
