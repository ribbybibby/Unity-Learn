using UnityEngine;
using System.Collections;

public class SpawnCena : MonoBehaviour {
	public GameObject Cena;

	void Update ()
	{
		float rndA = Random.Range (0.1f, 1000f);
		if (rndA < 5) 
		{
			float x = Random.Range (-9.0f, 8.5f);
			float y = Random.Range (-4.5f, 6.8f);
			//Vector3 pos = new Vector3 (x, y, 10f);
			//pos = Camera.main.ViewportToWorldPoint (pos);
			Instantiate (Cena, new Vector3 (x,y,-1), Quaternion.identity);
		}
	}
}
