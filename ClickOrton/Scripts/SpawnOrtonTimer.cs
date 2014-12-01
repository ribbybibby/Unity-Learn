using UnityEngine;
using System.Collections;

public class SpawnOrtonTimer : MonoBehaviour {

	public GameObject ortonSprite;
	public int i;
	public bool startAgain;
	public int rndNo;
	public float rndX;
	public float rndY;
	
	void Start () {
		i = 0;
		startAgain = true;
	}
	
	// Take a random number between 150 and 250, nudge 'i' up by one each update until we reach that number
	// Then create a new Orton and start again
	void Update () {
		if (Time.timeScale != 0F) {
			if (startAgain == true) {
				rndNo = Random.Range(0, 150);
				rndX = (Random.Range (-5.7F, 5F));
				rndY = (Random.Range (-3F, 4.5F));
				startAgain = false;
			}
			if (i < rndNo) {
				i++;
			}
			else {
				Instantiate (ortonSprite, new Vector3 (rndX, rndY, 0), Quaternion.identity);
				i = 0;
				startAgain = true;
			}
		}
	}
}
