using UnityEngine;
using System.Collections;

public class CenaMood : MonoBehaviour {

	// Set a fresh Orton to the default size and colour.
	void Start () {
		transform.localScale = new Vector3 (2, 2, 0);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	// When the amount of Ortons hits above a random number between 5 and 10 start increasing the size of the Ortons
	// each update.
	// When the Orton count is above (5, 10)+5 and rndGrow hits 10; we swap the colour to red
	void Update () {
		int ortonCount = GameObject.FindGameObjectsWithTag("Ortons").Length;
		int rndGrow = Random.Range(1,500);
		int rndLimit = Random.Range(5,10);
		if (ortonCount >= rndLimit) {
			transform.localScale += new Vector3 (0.005F, 0.005F, 0);
		}
		if (rndGrow == 10 & ortonCount >= rndLimit + 5) {
			GetComponent<SpriteRenderer>().color = Color.red;
		}					
	}
}
