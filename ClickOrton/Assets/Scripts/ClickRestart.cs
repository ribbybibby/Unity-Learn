using UnityEngine;
using System.Collections;

public class ClickRestart : MonoBehaviour {
	void Start () {
		transform.position = new Vector2 (10, 10);
	}

	void Update () {
		if (Time.timeScale == 0F) {
			transform.position = new Vector2 (0.7F, 1F);
		}
	}
	
	void OnMouseDown () {
		Time.timeScale = 1F;
		Application.LoadLevel (Application.loadedLevelName);
	}
 }

