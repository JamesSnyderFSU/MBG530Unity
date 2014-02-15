using UnityEngine;
using System.Collections;

public class scAsteroid : MonoBehaviour {

	float rangeStart = 20.0f;
	float rangeEnd = -15.0f;
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
			if (scPlayMove.shipDestroyed == false) {
				scScore.Increment();
			}
			moveAsteroid.z = rangeStart;
			moveAsteroid.x = Random.Range (-14, 14);
			SetSpeed();
			}

		// Perform movement
		transform.position = moveAsteroid;
	
	}

	// Detect collision between asteroid and player
	void OnCollisionEnter(Collision hitPlayer) {
		if (hitPlayer.gameObject.name == "colBoxShipPlayer") {
			scPlayMove.DestroyShip ();

			if (scScore.GetScore() > PlayerPrefs.GetInt ("High Score") ) {
				scScore.HighScore ();
				NewHighScore ();
			} else {
				scScore.GameOver ();
			}

			WaitForRestart();
			Application.LoadLevel ("sceneMenu");
		}
	}

	// Set random speed for next asteroid run
	void SetSpeed() {
		float randomSpeed = Random.Range (25, 100);
		asteroidSpeed = 1.0f * (randomSpeed / 100);
		}

	// Handle new high score and GPS information if new high score is earned
	// Note on GPS:  Would need to write plugin to translate GPS lat/long into useful location data, Unity Pro needed for plugins
	void NewHighScore() {
		// Write high score to player prefs
		PlayerPrefs.SetInt ("High Score", scScore.GetScore ());

		// Handle GPS Location here, save to player prefs
		string gpsInfo = "";

		if (Input.location.isEnabledByUser == true) {
			Input.location.Start ();

			int waitForService = 20;
			while (Input.location.status == LocationServiceStatus.Initializing && waitForService > 0) {
				Waiting ();
				waitForService -= 1;
			}

			if (waitForService < 0) {
				gpsInfo = "(GPS timed out)";
			} else {
				if (Input.location.status == LocationServiceStatus.Failed) {
					gpsInfo = "(GPS location failed)";
				} else {
					gpsInfo = Input.location.lastData.latitude + " lat";
					gpsInfo += " by " + Input.location.lastData.longitude + " long";
				}
			}

		} else {
			gpsInfo = "(GPS not enabled)";
		}

		// Write GPS data to player prefs
		PlayerPrefs.SetString ("High Loc", gpsInfo);
	}

	// Wait method for GPS initialization
	IEnumerator Waiting() {
		yield return new WaitForSeconds(1);
	}

	IEnumerator WaitForRestart() {
		yield return new WaitForSeconds(5);
	}

}