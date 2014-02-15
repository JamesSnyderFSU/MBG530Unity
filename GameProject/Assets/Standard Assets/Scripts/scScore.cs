using UnityEngine;
using System.Collections;

public class scScore : MonoBehaviour {

	// Set text styles
	public GUIStyle styScore;
	public GUIStyle styGameOver;

	// Set dynamic positioning
	private float posScore = (Screen.height / 20);
	private float lblWidth = (Screen.width / 8);
	private float lblHeight = (Screen.width / 8);

	// Set score
	static int score = 0;

	// Set game over variables
	static bool gameOver = false;
	static string gameOverText = "Game Over";

	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {

		// Score display
		GUI.Label (new Rect ((Screen.width - posScore - lblWidth), posScore, lblWidth, lblHeight), score.ToString (), styScore);

		// Game over display
		if (gameOver == true) {
			GUI.Label (new Rect (((Screen.width / 2) - lblWidth), ((Screen.height / 2) - lblHeight), lblWidth, lblHeight), gameOverText, styGameOver);
			}
		}

	public static void Increment() {
		score += 1;
		}

	public static void GameOver() {
		gameOverText = "Game Over";
		gameOver = true;
		}

	public static int GetScore() {
		return score;
		}

	public static void HighScore() {
		gameOver = true;
		gameOverText = "New High Score!";
		}

}
