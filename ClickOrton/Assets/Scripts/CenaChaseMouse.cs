using UnityEngine;
using System.Collections;

public class CenaChaseMouse : MonoBehaviour {

	void FixedUpdate () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector3(mousePosition.x + 0.5F, mousePosition.y - 0.5F, 0);
	}
}
