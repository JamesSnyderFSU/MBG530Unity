using UnityEngine;
using System.Collections;

public class scPlayMove : MonoBehaviour {

	private float speed = 1.0f;

	private float moveX;
	private float getAccel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Call moveShip function

		MoveShip ();

	}

	void MoveShip() {

		// Get accelerometer information for single axis, clamp within horizontal boundaries

		float getAccel = Input.acceleration.x * speed;
		Vector3 shipPosition = transform.position;
		shipPosition.x = Mathf.Clamp (shipPosition.x + getAccel, -14, 14);
		transform.position = shipPosition;

		}
}



