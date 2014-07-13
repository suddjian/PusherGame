using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
    float hitForce = 160f;
    float lifetime = 20f; // seconds before disappearing (-1 to stay forever)
    int destructionLayerMask = 1 << LayerMask.NameToLayer("Baddies");

    void Start() {
        if (lifetime != -1f) {
            Object.Destroy(gameObject, lifetime);
        }
    }

	void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Utils.Vector2Convert(transform.position) + rigidbody2D.velocity * Time.fixedDeltaTime);
        if (hit.collider != null && Utils.InLayerMask(hit.collider.gameObject.layer, destructionLayerMask)) {
            hit.collider.rigidbody2D.AddForceAtPosition(rigidbody2D.velocity.normalized * hitForce, hit.point);
			//Object.Destroy(hit.collider.gameObject);
        }
	}

    /*
    void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 30), "v: " + rigidbody2D.velocity);
        GUI.Label(new Rect(10, 60, 200, 30), "t: " + Time.fixedDeltaTime);
        GUI.Label(new Rect(10, 110, 500, 30), "G: " + Physics2D.gravity);
        GUI.Label(new Rect(10, 160, 500, 30), "g: " + rigidbody2D.gravityScale);
        GUI.Label(new Rect(10, 210, 500, 30), "m: " + rigidbody2D.mass);
    }
    */
}
