using UnityEngine;
using System.Collections;

public class SpawnOrton : MonoBehaviour {
	public GameObject ortonSprite;

	// On click, create between 1 and 3 new ortons at any location in the camera's view and then destroy the existing Orton
	void OnMouseDown(){
		int h = (Random.Range (1,3));
		int i = 0;
		while (i < h) {
						float rndX;
						float rndY;
						rndX = (Random.Range (-6F, 6F));
						rndY = (Random.Range (-3F, 4.5F));
						Instantiate (ortonSprite, new Vector3 (rndX, rndY, 0), Quaternion.identity);
						i++;
				}
		Destroy (gameObject);
	}
}
