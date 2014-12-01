using UnityEngine;
using System.Collections;

public class SpawnOrton : MonoBehaviour {
	public GameObject ortonSprite;
	public int h;
	public int i;
	public int v;
	public int b;
	public int rndNo;
	public float rndX;
	public float rndY;
	public bool startAgain;

	void Start(){
		v = 0;
		b = 0;
		startAgain = true;
	}

	void Update(){
		if (Time.timeScale == 1F) {
						if (GetComponent<SpriteRenderer> ().color == Color.yellow) {
								if (startAgain == true) {
										rndNo = Random.Range (0, 50);
										rndX = (Random.Range (-5.7F, 5F));
										rndY = (Random.Range (-3F, 4.5F));
										startAgain = false;
								}
								if (v < rndNo) {
										v++;
								} else {
										Instantiate (ortonSprite, new Vector3 (rndX, rndY, 0), Quaternion.identity);
										v = 0;
										startAgain = true;
								}
						}
						if (GetComponent<SpriteRenderer> ().color == Color.red) {
							if (b < 1000) {
								b++;
							}
							else {
								Destroy (gameObject);
							}
						}
				}
	}

	// On click, create 1 Orton and then destroy the existing Orton.
	// If the Orton is yellow, create 3 and then destroy.
	void OnMouseDown(){
		if (Time.timeScale != 0F) {

			if (GetComponent<SpriteRenderer> ().color == Color.red) {
				h = 5;
			}
			else {
				h = 0;
			}
			int i = 0;
			while (i < h) {
				rndX = (Random.Range (-5.7F, 5F));
				rndY = (Random.Range (-3F, 4.5F));
				Instantiate (ortonSprite, new Vector3 (rndX, rndY, 0), Quaternion.identity);
						i++;
				}
			Destroy (gameObject);
		}
	}
}