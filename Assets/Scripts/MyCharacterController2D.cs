using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class MyCharacterController2D : MonoBehaviour {
	
	public float speed = 1f;
   	public float jumpPower = 10f;
	public float jumpDelay = 0.3f; // the amount of time before the character can jump again
	public bool controlWhileJumping = true;
	//public Vector2 groundCheckPosition;
	//public Vector2 groundCheckSize;
	public Transform groundCheck;
	public LayerMask groundMask;

	private bool grounded = false;
	private float timeUntilJump = 0;
    //private Vector2 motion = Vector2.zero;

	void Update () {
		Vector2 grchScaleHalf = Utils.Vec3to2(groundCheck.localScale) * 0.5f;
		Vector2 grchA = Utils.Vec3to2(groundCheck.position) - grchScaleHalf;
		Vector2 grchB = Utils.Vec3to2(groundCheck.position) + grchScaleHalf;
		grounded = Physics2D.OverlapArea(grchA, grchB, groundMask);

		timeUntilJump -= Time.deltaTime;
		if (timeUntilJump < 0) {
			timeUntilJump = 0;
		}

		//Vector2 pos = Utils.Vec3to2(transform.position);
		//pos += motion;
		//pos += Physics2D.gravity * Time.fixedDeltaTime * rigidbody2D.gravityScale * rigidbody2D.mass;
		//transform.position = pos;
		//motion = Vector2.zero;
	}

	public void MoveHorizontal(float amount) {
		//motion.x += amount * speed;
		if (controlWhileJumping || grounded) {
			transform.position += new Vector3(amount * speed, 0, 0);
		}
	}

    public void TryJump() {
		if (grounded && timeUntilJump <= 0) {
			rigidbody2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
			grounded = false;
			timeUntilJump = jumpDelay;
			//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
		}
    }

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(groundCheck.position, groundCheck.localScale);
		/*
		Gizmos.DrawLine(new Vector3(grchA.x, grchA.y), new Vector3(grchB.x, grchA.y));
		Gizmos.DrawLine(new Vector3(grchB.x, grchA.y), new Vector3(grchB.x, grchB.y));
		Gizmos.DrawLine(new Vector3(grchB.x, grchB.y), new Vector3(grchA.x, grchB.y));
		Gizmos.DrawLine(new Vector3(grchA.x, grchB.y), new Vector3(grchA.x, grchA.y));
		*/
	}
}
