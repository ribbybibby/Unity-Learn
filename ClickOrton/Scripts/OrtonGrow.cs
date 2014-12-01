using UnityEngine;
using System.Collections;

public class OrtonGrow : MonoBehaviour {
	public GameObject ortonSprite;
	public int i;
	public float rndX;
	public float rndY;

	// Set a fresh Orton to the default size and colour.
	void Start () {
		transform.localScale = new Vector3 (2, 2, 0);
		GetComponent<SpriteRenderer> ().color = Color.white;
		i = 0;
	}

	/* Code for:
	 * 1. Increasing size
	 * 2. Turning Ortons red
	 * 3. Turning Ortons yellow
	 * 4. Exploding Red Ortons
	 */
	void Update () {
		if (Time.timeScale != 0F) {
			int ortonCount = GameObject.FindGameObjectsWithTag ("Ortons").Length;
			int rndGrow = Random.Range (1, 2500);
			int rndLimit = Random.Range (5, 20);
			int rndYellow = Random.Range (1, (ortonCount * 100));
			if (ortonCount >= rndLimit) {
					transform.localScale += new Vector3 (0.005F, 0.005F, 0);
			}
			if (rndGrow == 10) {
					GetComponent<SpriteRenderer> ().color = Color.red;
			}
			if (rndYellow == 2 & rndGrow/1.1 < 1000 & GetComponent<SpriteRenderer> ().color != Color.red) {
				GetComponent<SpriteRenderer> ().color = Color.yellow;
			}
		}
	}
	
}
