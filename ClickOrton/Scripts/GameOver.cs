using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Start () {
		transform.position = new Vector2 (10, 10);
	}
	// Update is called once per frame
	void Update () {
				if (Time.timeScale == 0F) {
						transform.position = new Vector2 (0.2F, 0.6F);				
				}
				if (Time.timeScale == 1F) {
						transform.position = new Vector2 (10F, 10F);
				}

		}
}
