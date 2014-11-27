using UnityEngine;
using System.Collections;

public class TimeScoreOrtons : MonoBehaviour {

	void Update () {
		float rndMult = Random.Range (2F, 3F);
		float textplace = transform.position.y;
		int ortonCount = GameObject.FindGameObjectsWithTag ("Ortons").Length;
		float timer = Time.timeSinceLevelLoad;
		float score = ortonCount * (timer * ortonCount) + (textplace + rndMult) * ortonCount;

		if (textplace == 1F) {
			gameObject.guiText.text = "ORTONS: " + (ortonCount);
		}
		if (textplace == 0.95F) {
			gameObject.guiText.text = "TIME: " + (timer);
		}
		if (textplace == 0.9F) {
			gameObject.guiText.text = "SCORE: " + (score);
		}
		if (Time.timeScale == 0 & textplace > 0.91F) {
			transform.position = new Vector2 (10, 10);
		}
		if (Time.timeScale == 0 & textplace == 0.9F) {
			transform.position = new Vector2 (0.39F, 0.35F);
			transform.localScale = new Vector2 (2, 2);
			gameObject.guiText.fontSize = 35;
			gameObject.guiText.text = " " + (score);
			gameObject.guiText.alignment = 0;
		}
		if (Time.timeScale == 1 & textplace == 0.35F) {
			transform.position = new Vector2 (-0.000473925F, 0.9F);
		}
	}
}
