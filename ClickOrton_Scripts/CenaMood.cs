using UnityEngine;
using System.Collections;

public class CenaMood : MonoBehaviour {

	// Set a fresh Orton to the default size and colour.
	void Start () {
		transform.localScale = new Vector3 (2, 2, 0);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	// When the amount of Ortons hits above a random number between 10 and 20 start increasing the size of the Ortons
	// each update.
	// When the Orton count is above (10, 20)+10 and rndGrow hits 10; we swap the colour to red
	void Update () {
		int ortonCount = GameObject.FindGameObjectsWithTag("Ortons").Length;
		int rndGrow = Random.Range(1,1000);
		int rndLimit = Random.Range(10,20);
		if (ortonCount >= rndLimit) {
			transform.localScale += new Vector3 (0.005F, 0.005F, 0);
		}
		if (rndGrow == 10 & ortonCount >= rndLimit + 10) {
			GetComponent<SpriteRenderer>().color = Color.red;
		}					
	}
}
