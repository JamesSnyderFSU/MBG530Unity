using UnityEngine;
using System.Collections;

public class scPlayfield : MonoBehaviour {

	// Set speeds for texture scroll

	public float speedLayerStar = 1.0f;
	public float speedLayerDust = 2.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Offset for texture scrolling

		float offsetLayerStar = (speedLayerStar * Time.time) * -1;
		float offsetLayerDust = (speedLayerDust * Time.time) * -1;

		// Handle offset of self-illum starfield texture

		renderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0.0f, offsetLayerStar));
		renderer.materials[0].SetTextureOffset("_Illum", new Vector2(0.0f, offsetLayerStar));

		// Handle offset of transparent/diffuse cloud texture

		renderer.materials[1].SetTextureOffset("_MainTex", new Vector2(0.0f, offsetLayerDust));

	}

}