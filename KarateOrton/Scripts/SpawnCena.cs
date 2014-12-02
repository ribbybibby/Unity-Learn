using UnityEngine;
using System.Collections;

public class SpawnCena : MonoBehaviour {
	public GameObject Cena;

	void Update ()
	{
		float rndA = Random.Range (0f, 500f);
		if (rndA < 5) 
		{
			float x = Random.Range (-16f, 16f);
			float y = Random.Range (1f, 13f);
			//Vector3 pos = new Vector3 (x, y, 10f);
			//pos = Camera.main.ViewportToWorldPoint (pos);
			Instantiate (Cena, new Vector3 (x,y,-1), Quaternion.identity);
		}
	}
}
