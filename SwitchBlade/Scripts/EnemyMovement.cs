using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public int jumpForce; //Force of jump 
	public float speed; // Speed of movement
	public float xRight; // Right bound
	public float xLeft; // Left bound
	public float yTop; // Top bound
	public float yBottom; // Bottom bound

	GameObject FindWeakPlayer (){
		GameObject[] targets;
		targets = GameObject.FindGameObjectsWithTag ("weak");
		GameObject target = targets[0];
		return target;
	}
		

	// On collision, apply force upwards and then left/right depending on the Weak Player's relation to this object on the X-axis
	void OnCollisionEnter2D(Collision2D col) {
		rigidbody2D.AddForce (Vector3.up * jumpForce);
		float targetdiff = (FindWeakPlayer().transform.position.x) - transform.position.x;
	
		if (targetdiff > 0f) 
		{	
			rigidbody2D.AddForce (Vector3.right * speed);
		}
		if (targetdiff < 0) 
		{
			rigidbody2D.AddForce (Vector3.left * speed);
		}
	}

	// The lowest floor is contained in a special layer (9); if the Enemy hits it, 
	// he is spawned back at a random point inside the bounds (prevents floor clusters,
	// maintains pace of gameplay.
	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.layer == 9) 
		{
			float x = Random.Range (xLeft, xRight);
			float y = Random.Range (yBottom, yTop);
			transform.position = new Vector2 (x, y); 
		}

		// If this object gets stuck for too long on any surface, we give it a strong force 
		//towards the player to try and dislodge it 
		float rndNo = Random.Range (1, 10);
		if (rndNo == 3) {
			float targetdiff = (FindWeakPlayer().transform.position.x) - transform.position.x;
			if (targetdiff > 0f) {	
				rigidbody2D.AddForce (Vector3.right * speed / 2);
			}
			if (targetdiff < 0) {
				rigidbody2D.AddForce (Vector3.left * speed / 2);
			}
		}
	}
}
