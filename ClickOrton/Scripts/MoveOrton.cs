﻿using UnityEngine;
using System.Collections;

public class MoveOrton : MonoBehaviour {

	// Move Orton up, down, left or right based on a Random number
	// Creates an eerie shake effect (y)
	void Update () {
		float rndMove;
		rndMove = (Random.Range(0F,20F));

		if (rndMove > 0F & rndMove < 5F ) {
			transform.Translate (Vector3.up * Time.deltaTime, Space.World);			
		}
		if (rndMove > 5F & rndMove < 10F) {
			transform.Translate (Vector3.down * Time.deltaTime, Space.World);				
		}
		if (rndMove > 10F & rndMove < 15F) {
			transform.Translate (Vector3.right * Time.deltaTime, Space.World);				
		}
		if (rndMove > 15F & rndMove < 20F) {
			transform.Translate (Vector3.left * Time.deltaTime, Space.World);				
		}
	}
}
