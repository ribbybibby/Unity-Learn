using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

	// Set in Unity
	public PlayerController playerOne; // Player 1
	public PlayerController playerTwo; // Player 2
	public float xRight; // Right bound
	public float xLeft; // Left bound
	public float yTop; // Top bound
	public float yBottom; // Bottom bound

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "weak") 
		{

			playerOne.ChangeMode();
			playerTwo.ChangeMode();
			float x = Random.Range (xLeft, xRight);
			float y = Random.Range (yBottom, yTop);
			Instantiate(gameObject, new Vector2(x,y), Quaternion.identity);
			Destroy(gameObject);

		}
	}

}
