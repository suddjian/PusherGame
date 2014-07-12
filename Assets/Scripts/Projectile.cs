using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Projectile : MonoBehaviour {
	
    long lifetime = 30000; // milliseconds before disappearing (-1 to stay forever)
    int destructionLayerMask = 1 << LayerMask.NameToLayer("Baddies");

    private Stopwatch timer;

    void Start() {
        Object.Destroy(gameObject, lifetime);
    }

	void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Utils.Vector2Convert(transform.position) + rigidbody2D.velocity);
        if (hit.collider != null && Utils.InLayerMask(hit.collider.gameObject.layer, destructionLayerMask)) {
            Object.Destroy(hit.collider.gameObject);
        }
	}
}
