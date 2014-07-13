using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private bool grounded;
	
	public bool isGrounded() {
		return grounded;
	}

	void OnTriggerEnter2D(Collider2D other) {
		grounded = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		grounded = false;
	}
}
