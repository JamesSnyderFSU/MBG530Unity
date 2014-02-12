using UnityEngine;
using System.Collections;

public class scPlayfield : MonoBehaviour {

	float speedLayerStar = 0.0f;
	float speedLayerDust = 0.0f;

	// Use this for initialization
	void Start () {
		/*Vector3 scale = transform.localScale;
		scale.x = 10f;
		scale.z = 5f;
		transform.localScale = scale;
		Debug.Log ("x" + scale.x + ".z" + scale.z);

		/*float fieldXScale = 3.5f; //Screen.width;
		float fieldZScale = 7.5f; //Screen.height;
		transform.localScale = new Vector3(fieldXScale, 1.0f, fieldZScale);*/
	}
	
	// Update is called once per frame
	void Update () {

		// Handle scrolling of texture

		float offsetLayerStar = (speedLayerStar * Time.time) * -1;
		float offsetLayerDust = (speedLayerDust * Time.time) * -1;

		renderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0.0f, offsetLayerStar));
		renderer.materials[0].SetTextureOffset("_BumpMap", new Vector2(0.0f, offsetLayerStar));
		renderer.materials[1].SetTextureOffset("_MainTex", new Vector2(0.0f, offsetLayerDust));
		renderer.materials[1].SetTextureOffset("_BumpMap", new Vector2(0.0f, offsetLayerDust));
	}
}
