using UnityEngine;
using System.Collections;

public class scAsteroid : MonoBehaviour {

	float rangeStart = 20.0f;
	float rangeEnd = -20.0f;
	float asteroidSpeed = 1.0f;

	// Use this for initialization
	void Start () {

		// Set asteroid start position randomly along random range

		float posStart = Random.Range (-14, 14);

		Vector3 asteroidPosition = transform.position;
		asteroidPosition.z = rangeStart;
		asteroidPosition.x = posStart;
		transform.position = asteroidPosition;
		SetSpeed ();

	}
	
	// Update is called once per frame
	void Update () {

		// Prepare to adjust asteroid position
		Vector3 moveAsteroid = transform.position;
		moveAsteroid.z = moveAsteroid.z - asteroidSpeed;

		// If asteroid goes beyond range, move to beginning of the field to new random spot
		if (moveAsteroid.z < rangeEnd) {
			moveAsteroid.z = rangeStart;
			moveAsteroid.x = Random.Range (-14, 14);
			SetSpeed();
			scScore.Increment();
				}

		// Perform movement
		transform.position = moveAsteroid;
	
	}

	void SetSpeed() {
		float randomSpeed = Random.Range (25, 100);
		asteroidSpeed = 1.0f * (randomSpeed / 100);
		}
}
