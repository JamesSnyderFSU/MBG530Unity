using UnityEngine;
using System.Collections;

public class scMenuMain : MonoBehaviour {

	float btWidth = (Screen.width / 4) * 2;
	float btHeight = (Screen.height / 10);
	float btposLeft = (Screen.width / 2) - (Screen.width / 4);
	float btposTop = (Screen.height / 4) * 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Create main GUI

	void OnGUI () {
		GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");

		if(GUI.Button (new Rect(btposLeft, btposTop, btWidth, btHeight), "Start Game")) {
			Application.LoadLevel("sceneMain");
		}

		if(GUI.Button (new Rect(btposLeft, btposTop + (btHeight * 3), btWidth, btHeight), "Quit Game")) {
			// End Game
			Application.Quit();
		}

	}



}
