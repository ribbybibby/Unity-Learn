using UnityEngine;
using System.Collections;

public class SphereCast : MonoBehaviour {
	void Start () {
		Time.timeScale = 1F;
	}

	void Update () {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2.0F, 1 << LayerMask.NameToLayer("Ortons"));
		if (hitColliders.Length > 25) {
			Time.timeScale = 0;
		}
	}
}
