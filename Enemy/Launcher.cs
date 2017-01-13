using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	GameObject bird;
	public GameObject launchPrefab;
	public GameObject roof;
	bool fire = true;
	public float fireDelay = 3f;

	float nextFire = 0.5f;
	public float fireVelocity = 30f;

	// Use this for initialization
	void Start () {
		bird = GameObject.Find ("Birdy");
		//find out who the 'thrower' is
		switch (this.name) {
		case "watercarGO(Clone)":
//			Debug.Log ("WATERCAR");
			break;
		case "robotGO(Clone)":
//			Debug.Log ("ROBOTO");
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		nextFire -= Time.deltaTime;

		if (fire && nextFire <= 0.0f) {
			GameObject launchThis = (GameObject)Instantiate (launchPrefab, transform.position, transform.rotation);
			fire = false;
			if (this.name == "robotGO(Clone)") {
				Vector3 angle = new Vector3 (-4.0f, 4.0f, 0.0f);
				launchThis.GetComponent<Rigidbody2D>().velocity = angle;
				launchThis.transform.up = launchThis.transform.GetComponent<Rigidbody2D> ().velocity;

				launchThis.GetComponent<Rigidbody2D> ().isKinematic = false;
				launchThis.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			}else {
				//Debug.Log (": " + this.name);
				float rnd = Random.Range(-1,7);
				launchThis.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (-5.0f, fireVelocity+rnd);
			}
			Physics2D.IgnoreCollision (launchThis.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
			Physics2D.IgnoreCollision (launchThis.GetComponent<Collider2D> (), roof.GetComponent<Collider2D> ());
		}
	}
}
