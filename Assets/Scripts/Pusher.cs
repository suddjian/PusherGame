using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

	public Vector2 checkLocation;
	public Vector2 pushForce = new Vector2(10, 0);
	public LayerMask collisionMask;
	public bool pushing;

	private Vector3 lastPosition;

	void Start() {
		lastPosition = transform.position;
	}

	void Update() {
		if (pushing) {
			RaycastHit2D hit = Physics2D.Linecast(lastPosition + Utils.Vec2to3(checkLocation), transform.position + Utils.Vec2to3(checkLocation), collisionMask);
			Debug.DrawLine(lastPosition + Utils.Vec2to3(checkLocation), transform.position + Utils.Vec2to3(checkLocation));
			if (hit.collider && hit.collider.rigidbody2D) {
				hit.collider.rigidbody2D.AddForceAtPosition(pushForce, hit.point, ForceMode2D.Impulse);
        	}
		}
		lastPosition = transform.position;
    }

	public void Push() {
		animation.Play();
		lastPosition = transform.position;
	}

	public void Flip() {
		checkLocation.x = -checkLocation.x;
		pushForce.x = -pushForce.x;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, transform.position + Utils.Vec2to3(checkLocation));
		Gizmos.DrawCube(transform.position + Utils.Vec2to3(checkLocation), new Vector3(0.1f, 0.1f, 0.1f));
	}
}
