using UnityEngine;
using System.Collections;

public class MoveCena : MonoBehaviour {
	
	void Update () {
		if (Time.timeScale != 0F) {

			float rndMove;
			rndMove = (Random.Range (0F, 200F));
		
			if (rndMove > 0F & rndMove < 75F) {
				transform.position += new Vector3 (0.01F, 0, 0);			
			}
	
		} 
		else {
			transform.position = new Vector2(10F,10F);				
		}

	}
}
