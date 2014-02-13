using UnityEngine;
using System.Collections;

public class scScore : MonoBehaviour {

	static int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {

		}

	public static void Increment() {
		score += 10;
		}
}
