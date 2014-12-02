using UnityEngine;
using System.Collections;

public class SpawnCena : MonoBehaviour {
	public GameObject Cena;
	public float xRight;
	public float xLeft;
	public float yTop;
	public float yBottom;

	void Update ()
	{
		// 5/501 chance to Spawn a new Cena every frame at a point in the designated range
		float rndA = Random.Range (0f, 500f);
		if (rndA < 5) 
		{
			float x = Random.Range (xLeft, xRight);
			float y = Random.Range (yBottom, yTop);
			Instantiate (Cena, new Vector3 (x,y,-1), Quaternion.identity);
		}
	}
}
