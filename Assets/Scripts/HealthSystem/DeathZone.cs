using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class DeathZone : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D other) {
		OnTriggerEnter2D(other.collider);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Health.Die(other);
	}
}
