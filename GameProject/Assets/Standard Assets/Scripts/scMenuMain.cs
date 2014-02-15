using UnityEngine;
using System.Collections;

public class scMenuMain : MonoBehaviour {

	// Set public variable to include texture for logo

	public Texture2D txMainLogo;
	public GUIStyle scoreHigh;

	// Set dynamic object positions

	private float btWidth = (Screen.width / 4) * 2;
	private float btHeight = (Screen.height / 10);
	private float btposLeft = (Screen.width / 2) - (Screen.width / 4);
	private float btposTop = (Screen.height / 4) * 2;
	private float bxLogoHeight = (Screen.height / 8);

	// Create main GUI

	void OnGUI () {

		GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");

		GUI.Box (new Rect (btposLeft, bxLogoHeight, btWidth, bxLogoHeight), txMainLogo);

		if(GUI.Button (new Rect(btposLeft, btposTop, btWidth, btHeight), "Start Game")) {
			Application.LoadLevel("sceneMain");
		}

		if(GUI.Button (new Rect(btposLeft, btposTop + (btHeight * 3), btWidth, btHeight), "Quit Game")) {
			// End Game
			Application.Quit();
		}

		if (GUI.Button (new Rect (btposLeft, btposTop + (btHeight * 1.75f), btWidth, btHeight), "Reset Data")) {
			PlayerPrefs.DeleteAll();
		}

		if (PlayerPrefs.GetInt ("High Score") > 0) {
			string highScoreShow = "";
			highScoreShow = "High Score of " + PlayerPrefs.GetInt ("High Score") + " earned at " + PlayerPrefs.GetString ("High Loc") + ".";
			GUI.Label (new Rect(0, btposTop - (btHeight * 2), Screen.width, btHeight), highScoreShow, scoreHigh);
		}

	}

}