using UnityEngine;
using System.Collections;

public class scPlayMove : MonoBehaviour {

	// Set ship state
	public static bool shipDestroyed = false;

	// Set explosion particle
	public GameObject partExplode;

	// Set ship variables

	private float speed = 1.0f;
	private float moveX;
	private float getAccel;

	// Use this for initialization
	void Start () {
		shipDestroyed = false;
		ResetShip ();
	}
	
	// Update is called once per frame
	void Update () {
		if (shipDestroyed == false) {
			MoveShip ();
		} else {
			HideShip ();
		}
	}

	void MoveShip() {

		// Get accelerometer information for single axis, clamp within horizontal boundaries

		float getAccel = Input.acceleration.x * speed;
		Vector3 shipPosition = transform.position;
		shipPosition.x = Mathf.Clamp (shipPosition.x + getAccel, -14, 14);
		transform.position = shipPosition;
		}


	public static void DestroyShip() {
		shipDestroyed = true;
		}

	void ResetShip() {
		Vector3 shipReset = transform.position;
		shipReset.x = 0.0f;
		shipReset.y = 0.125f;
		shipReset.z = -6.5f;
		transform.position = shipReset;
		}

	void HideShip() {
		// Get ship's current position
		Vector3 shipHide = transform.position;
		Vector3 showParticle = transform.position;

		// Display particle explosion
		GameObject showExplode = Instantiate (partExplode, showParticle, transform.rotation) as GameObject;
		Destroy (showExplode, 1.5f);

		// Move ship offscreen
		shipHide.z = -50f;
		transform.position = shipHide;
		}

}