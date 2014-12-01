using UnityEngine;
using System.Collections;

public class CenaChaseMouse : MonoBehaviour {

	//If the game is un-paused, Cena follows the mouse (offset by 0.5 in each axis)
	// If paused, hide the object at (10,10)
	void FixedUpdate () {
		if (Time.timeScale == 1F) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3 (mousePosition.x + 0.5F, mousePosition.y - 0.5F, 0);
		} 
		if (Time.timeScale == 0F) {
			transform.position = new Vector3 (10, 10, 0);
		}
	}
}
