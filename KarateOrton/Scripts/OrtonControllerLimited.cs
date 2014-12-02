using UnityEngine;
using System.Collections;

public class OrtonControllerLimited : MonoBehaviour {
	
	// Set in Unity 
	public float speed; //Player move speed
	public int kickForce; // Force of kick
	public int jumpLimit; // Number of jumps allowed before having to return to the floor
	public int jumpHeight; //Jump Height
	public Texture normalTexture; //Normal player texture
	public Texture redTexture; //Texture of attacking player

	// Leave blank in Unity
	public int jumpsMade; //Number of jumps performed since leaving the ground
	public bool readyToKick; //Is object able to attack?


	void Start () {
		readyToKick = true;
		jumpsMade = 0;
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
		//Jump
		if (Input.GetKeyDown (KeyCode.W))
		{
			if (jumpsMade < jumpLimit)
			{
				rigidbody2D.AddForce (Vector2.up * jumpHeight);
				jumpsMade++;
			}
		}
		// Add left or right force dependent on rotation, swap red 'attack' texture in
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
		// If red orton hits Cena enemy: destroy Cena
		if (gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture == redTexture & col.gameObject.tag == "Cena") 
		{
			Destroy(col.gameObject);
		}
		// If Cena enemy hits normal Cena: destroy Orton, restart level
		if (gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture == normalTexture & col.gameObject.tag == "Cena") 
		{
			Destroy(gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
		// If Orton hits a piece of floor, reset the available jumps and switch back to normal texture 
		if (col.gameObject.tag == "Ground") 
		{
			jumpsMade = 0;
			gameObject.GetComponent<MeshRenderer> ().materials [0].mainTexture = normalTexture;
		}
	}
	
	// Make sure dash/kick is always available after leaving a bit of floor
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			readyToKick = true;
		}
	}
}
	