using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 1f;
    public float hitForce = 160f;
    public float lifetime = 20f; // seconds before disappearing (-1 to stay forever)
	public LayerMask collisionMask;

	public float mass = 0.1f;
	public Vector2 velocity;
	public float gravityScale = 0.1f;
	public float drag = 0;

    void Start() {
        if (lifetime != -1f) {
            Object.Destroy(gameObject, lifetime);
        }
    }

	void Update() {
		Utils.LookAt2D(transform, Utils.Vec3to2(transform.position) + velocity);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Utils.Vec3to2(transform.position) + velocity * 1.05f * Time.deltaTime, collisionMask);
		Debug.DrawLine(transform.position, transform.position + Utils.Vec2to3(velocity) * Time.deltaTime);
        if (hit.collider != null) {
			HitTarget(hit);
		}
		transform.position = transform.position + Utils.Vec2to3(velocity * Time.deltaTime);
		ApplyGravity();
		ApplyDrag();
	}

	protected void ScheduleDestruction() {
		Object.Destroy(gameObject);
	}

	protected void ApplyGravity() {
		velocity += Physics2D.gravity * gravityScale * mass * Time.deltaTime;
	}

	protected void ApplyDrag() {
		velocity /= drag * Time.deltaTime + 1; // + 1 makes it so that 0 drag means no drag, otherwise 1 would mean no drag and 0.5 would actually mean negative drag
	}

	void HitTarget(RaycastHit2D hit) {
		if (hit.collider.rigidbody2D != null) {
			hit.collider.rigidbody2D.AddForceAtPosition(velocity.normalized * hitForce, hit.point);
		}
		Health h = hit.collider.GetComponent<Health>();
		if (h != null) {
			h.ApplyDamage(damage);
		}
		CameraShake.Shake(CameraShake.DefaultIntensity * 2);
		ScheduleDestruction();
	}

    /*
	// testing
    void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 30), "v: " + rigidbody2D.velocity);
        GUI.Label(new Rect(10, 60, 200, 30), "t: " + Time.fixedDeltaTime);
        GUI.Label(new Rect(10, 110, 500, 30), "G: " + Physics2D.gravity);
        GUI.Label(new Rect(10, 160, 500, 30), "g: " + rigidbody2D.gravityScale);
        GUI.Label(new Rect(10, 210, 500, 30), "m: " + rigidbody2D.mass);
    }
    */
}
