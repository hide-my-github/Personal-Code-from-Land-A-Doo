using UnityEngine;
using System.Collections;

public class EnemyBirdPooper : MonoBehaviour {

	public GameObject enemyPoopPrefab;
	public float fireDelay = 3f;
	float nextFire = 1f;

	public float fireVelocity = 10f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		nextFire -= Time.deltaTime;

		if (nextFire <= 0) {

			nextFire = fireDelay;
			GameObject launchThis = (GameObject)Instantiate (enemyPoopPrefab, transform.position, transform.rotation);
			Physics2D.IgnoreCollision (launchThis.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
		}
	}
}
