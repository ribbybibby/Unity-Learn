using UnityEngine;
using System.Collections;

public class CenaMovement : MonoBehaviour {
	public int jumpForce; //Force of jump 
	public Transform target;
	public float speed;
	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	public float targetX;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col) {


		rigidbody2D.AddForce (Vector3.up * jumpForce);
		float targetdiff = target.position.x - transform.position.x;
	
		if (targetdiff > 0f) 
		{	
			rigidbody2D.AddForce (Vector3.right * speed);
		}
		if (targetdiff < 0) 
		{
			rigidbody2D.AddForce (Vector3.left * speed);
		}


	}


	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.layer == 9) 
		{
			float x = Random.Range (-16f, 16f);
			float y = Random.Range (1f, 13f);
			transform.position = new Vector2 (x, y); 
		}

		float rndNo = Random.Range (1, 4);
		if (rndNo == 3) {
			float targetdiff = target.position.x - transform.position.x;
			if (targetdiff > 0f) {	
				rigidbody2D.AddForce (Vector3.right * speed / 2);
			}
			if (targetdiff < 0) {
				rigidbody2D.AddForce (Vector3.left * speed / 2);
			}
		}
	}
}