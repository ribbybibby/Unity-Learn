using UnityEngine;
using System.Collections;

public class OrtonController : MonoBehaviour {

	//Set in 
	public float speed; //Player move speed
	public int jumpHeight; //Jump Height
	public int kickForce; // Force of kick
	public Texture normalTexture;
	public Texture redTexture;
	public bool readyToKick;

	void Start () {
		readyToKick = true;
	}
	
	void Update () 
	{
		//Move Right
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0); 
		}
		//Move Left
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0,0,180); //flip the character on its x axis
		}
		if (Input.GetKeyDown (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpHeight);
		}
		if (Input.GetKeyDown (KeyCode.K)) 
		{
			if (transform.eulerAngles.z < 170 & readyToKick == true)
			{ 
				readyToKick = false;
				gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture = redTexture;
				rigidbody2D.AddForce (Vector3.right * kickForce);
			}
			if (transform.eulerAngles.z > 170 & readyToKick == true)
			{
				readyToKick = false;
				gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture = redTexture;
				rigidbody2D.AddForce (Vector3.left * kickForce);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture == redTexture & col.gameObject.tag == "Cena") {
			Destroy(col.gameObject);
		}
		readyToKick = true;
		gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture = normalTexture;
	}
	
}
