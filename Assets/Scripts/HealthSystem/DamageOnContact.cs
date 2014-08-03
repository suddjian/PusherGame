using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour {

	public LayerMask mask;
	public float damage;

	void OnTriggerEnter2D(Collider2D other) {
		if (Utils.InLayerMask(other.gameObject.layer, mask)) {
			Health.ApplyDamage(other, damage);
		}
	}
}
