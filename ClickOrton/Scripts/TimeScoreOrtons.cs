using UnityEngine;
using System.Collections;

public class TimeScoreOrtons : MonoBehaviour {
	public float posX;
	public float posY;

	// Find the starting position of the GUI element
	void Start () {
		posX = transform.position.x;
		posY = transform.position.y;
	}

	// Assign the values each GUI object tracks by the text
	// Hide or Move GUI based on text
	void Update () {
		int ortonCount = GameObject.FindGameObjectsWithTag ("Ortons").Length;
		float timer = Time.timeSinceLevelLoad;

		if (gameObject.guiText.text.Contains("ORTONS:")) {
			gameObject.guiText.text = "ORTONS: " + (ortonCount);
		}
		if (gameObject.guiText.text.Contains("TIME:")) {
			gameObject.guiText.text = "TIME: " + (timer);
		}
		//if (gameObject.guiText.text.Contains("SCORE:")) {
		//	gameObject.guiText.text = "SCORE: " + (score);
		//}
		if (Time.timeScale == 0 & gameObject.guiText.text.Contains("ORTONS:")) {
			transform.position = new Vector2 (10, 10);
		}
		if (Time.timeScale == 0 & gameObject.guiText.text.Contains("TIME:")) {
			transform.position = new Vector2 (0.39F, 0.35F);
			transform.localScale = new Vector2 (2, 2);
			gameObject.guiText.fontSize = 35;
			gameObject.guiText.alignment = 0;
		}
	}
}
