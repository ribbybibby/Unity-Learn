using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {
	public bool JumpLimitOn;
	
	// Update is called once per frame
	void OnMouseDown () {
		if (JumpLimitOn == true) {
			Application.LoadLevel (1);
		}
		if (JumpLimitOn == false) {
			Application.LoadLevel(0);
		}
	}

}
