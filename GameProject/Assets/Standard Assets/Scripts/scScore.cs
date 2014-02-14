using UnityEngine;
using System.Collections;

public class scScore : MonoBehaviour {

	public GUIStyle styScore;

	private float posScore = (Screen.height / 20);
	private float lblWidth = (Screen.width / 8);
	private float lblHeight = (Screen.width / 8);

	static int score = 0;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		GUI.Label (new Rect ((Screen.width - posScore - lblWidth), posScore, lblWidth, lblHeight), score.ToString (), styScore);
		}

	public static void Increment() {
		score += 1;
		}
}
