using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MyCharacterController2D))]
public class Player : MonoBehaviour {

	public float walkSpeed = 8f;
	public float sprintSpeed = 10f;
	public Pusher pusher;

	private MyCharacterController2D control;

	void Start() {
		control = GetComponent<MyCharacterController2D>();
		control.speed = walkSpeed;
	}

	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) {
			control.speed = sprintSpeed;
		} else {
			control.speed = walkSpeed;
		}
		if (Input.GetKey(KeyCode.D)) {
			control.MoveHorizontal(1 * Time.deltaTime);
			if (transform.localScale.x < 0 ) {
				Flip ();
			}
		}
		if (Input.GetKey(KeyCode.A)) {
			control.MoveHorizontal(-1 * Time.deltaTime);
			if (transform.localScale.x > 0 ) {
				Flip ();
			}
		}
		if (Input.GetKey(KeyCode.Space)) {
			control.TryJump();
		}
		if (Input.GetMouseButtonDown(0)) {
			pusher.Push();
		}
	}

	public void Flip() {
		Vector3 scale = transform.localScale;
		scale.x = -scale.x;
		transform.localScale = scale;
		pusher.Flip();
	}
}
