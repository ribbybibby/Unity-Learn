using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Set these in Unity
	public float speed; //Player move speed
	public int kickForce; // Force of kick
	public int jumpLimit; // Number of jumps allowed before having to return to the floor
	public int jumpHeight; //Jump Height
	public bool strong; //Is the character weak or strong? 
						//(currently we switch this in Start, so put the reverse of what you want in Unity
	public KeyCode moveRight; // Right
	public KeyCode moveLeft; // Left
	public KeyCode moveJump; // Jump
	public KeyCode moveDash; // Dash
	public Material[] materials; //0 = Strong, 1 = Weak, 2 = Attack

	// Private
	private int jumpsMade; //Number of jumps performed since leaving the ground
	private bool readyToKick; //Is object able to attack?
	private int fixedJumps; //Save the user-set jumpLimit
	private float fixedSpeed; //Save the user-set fixedSpeed
	private int matreset; // The current material for the object, 0 = Strong, 1 = Weak


	// Use this for initialization
	void Start () {
		// Set up variables
		readyToKick = true;
		jumpsMade = 0;
		fixedJumps = jumpLimit;
		fixedSpeed = speed;

		// Change between strong and weak, makes sure everything is set right at the start 
		ChangeMode ();
	}
	
	void Update () 
	{
		//Move Right
		if (Input.GetKey (moveRight)) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0); 
		}
		//Move Left
		if (Input.GetKey (moveLeft)) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector3(0,0,180); //flip the character on its x axis
		}
		//Jump
		if (Input.GetKeyDown (moveJump))
		{
			if (jumpsMade < jumpLimit)
			{
				rigidbody2D.AddForce (Vector2.up * jumpHeight);
				jumpsMade++;
			}
		}
		// Add left or right force dependent on rotation, swap red 'attack' texture in
		if (strong == true)
		{
			if (Input.GetKeyDown (moveDash)) 
			{
				if (transform.eulerAngles.z < 170 & readyToKick == true)
				{ 
					readyToKick = false;
					renderer.material = materials[2];
					rigidbody2D.AddForce (Vector3.right * kickForce);
				}
				if (transform.eulerAngles.z > 170 & readyToKick == true)
				{
					readyToKick = false;
					renderer.material = materials[2];
					rigidbody2D.AddForce (Vector3.left * kickForce);
				}
			}
		}	
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		// If red orton hits Cena enemy: destroy Cena
		if (gameObject.renderer.material.name == "Angry (Instance)" & (col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy(Clone)")) 
		{
			Destroy(col.gameObject);
		}
		// If Cena enemy hits normal Orton: destroy Orton, restart level
		else if (col.gameObject.tag == "enemy") 
		{
			Destroy(gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
		// If Orton hits a piece of floor, reset the available jumps and switch back to normal texture 
		else if (col.gameObject.tag == "Ground") 
		{
			jumpsMade = 0;
			renderer.material = materials[matreset];
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

	public void ChangeMode()
	{
		if (strong == true) 
		{
			// Weak
			matreset = 1;
			renderer.material = materials[1];
			jumpLimit = 1;
			speed = speed/3;
			strong = false;
			gameObject.tag = "weak";
		}
		else 
		{
			// Strong
			matreset = 0;
			renderer.material = materials[0];
			jumpLimit = fixedJumps;
			speed = fixedSpeed;
			strong = true;
			gameObject.tag = "strong";
		}
	}
}



