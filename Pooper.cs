using UnityEngine;
using System.Collections;

public class Pooper : MonoBehaviour {

	public GameObject poops;
	public GameObject bird;
	public GameObject bg; //background
	public bool firePoop;
	// Use this for initialization
	public float fireDelay = 3f;
	public float initVelocity = 30f;

	void Update() {
	}

	void FixedUpdate () {
	}


	public void dropPoopFunc (){
			Vector2 v2 = new Vector2(0.0f, -1.0f);

			GameObject poopGO = (GameObject)Instantiate (poops, bird.transform.position, Quaternion.identity);

			poopGO.GetComponent<Rigidbody2D> ().velocity = (v2 * initVelocity) + new Vector2 (3f, 0);
			Physics2D.IgnoreCollision (poopGO.GetComponent<Collider2D> (), bird.GetComponent<Collider2D> ());
	}

	public void tapPoopFunc(Vector2 end){
			Vector2 v2 = new Vector2 (end.x - bird.transform.position.x, end.y - bird.transform.position.y);
			v2 = v2.normalized;

			GameObject poopGO = (GameObject)Instantiate (poops, bird.transform.position, Quaternion.identity);
			
			//increment number of Doos for stats
			StatsScript.numOfDoos++;

			poopGO.GetComponent<Rigidbody2D> ().velocity = (v2 * initVelocity) + new Vector2 (3f, 0);
			Debug.Log (bird.transform.GetChild (2).name);
			GameObject birdChild = GameObject.Find(bird.transform.GetChild(2).name);
			Physics2D.IgnoreCollision (poopGO.GetComponent<Collider2D>(), birdChild.GetComponent<Collider2D> ());
	}

	public void firePoopFunc (Vector2 start, Vector2 end){
			
		bool goodDistance = false;
		Vector2 difference = new Vector2 (start.x - end.x, start.y - end.y);
		float distance = Mathf.Sqrt (Mathf.Pow (difference.x, 2f) + Mathf.Pow (difference.y, 2f));
		//Debug.Log ("Distance: " + distance);
		if (distance >= 0.5)
			goodDistance = true;
		if (start.y >= end.y) {
				Vector2 v2 = end - start;
				v2 = v2.normalized;

				GameObject poopGO = (GameObject)Instantiate (poops, bird.transform.position, Quaternion.identity);

				poopGO.GetComponent<Rigidbody2D> ().velocity = (v2 * initVelocity) + new Vector2 (3f, 0);
				
				GameObject birdChild = GameObject.Find (bird.transform.GetChild (2).name);
				Physics2D.IgnoreCollision (poopGO.GetComponent<Collider2D> (), birdChild.GetComponent<Collider2D> ());
		} else if (goodDistance) {
			Debug.Log ("shooting up against gravity?");
		} else {
			Debug.Log ("not long enough!");
		}
	}
}
