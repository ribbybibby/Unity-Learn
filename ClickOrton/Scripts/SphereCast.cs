using UnityEngine;
using System.Collections;

public class SphereCast : MonoBehaviour {
	// - Create a small circle collider on the Orton that detects other nearby Ortons
	// - If the number of Ortons is over 15, pause the time (game over)
	void Update () {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2.0F, 1 << LayerMask.NameToLayer("Ortons"));
		if (hitColliders.Length > 20) {
			GetComponent<SpriteRenderer> ().color = Color.green;
			Time.timeScale = 0F;
		}
	}
}
