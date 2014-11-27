using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
				if (transform.position.x >= 1 & transform.position.y >= -1) {
						transform.Translate (Vector3.down * Time.deltaTime, Space.World);			
				}
				if (transform.position.x > -0.6F & transform.position.y <= -1) {
						transform.Translate (Vector3.left * Time.deltaTime, Space.World);				
				}
				if (transform.position.x >= -0.6F & transform.position.x < -0.55F & transform.position.y < 2) {
						transform.Translate (Vector3.up * Time.deltaTime, Space.World);				
				}
				if (transform.position.x < 1 & transform.position.y >= 2) {
						transform.Translate (Vector3.right * Time.deltaTime, Space.World);				
				}
		}
}

	//void Move(int xDirection, int yDirection)
	//{
	//moving = true;
	
	//while(transform.position.x != xDirection && transform.position.z != yDirection)
	//{
		//transform.position.x += Mathf.Lerp(transform.position.x, transform.position.x + xDirection, speed);
		//transform.position.y += Mathf.Lerp(transform.position.z, transform.position.z + yDirection, speed);
		
	//}
	
	//moving = false;
	
	
	//}
