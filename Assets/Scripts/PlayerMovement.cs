using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 10f;
    public float jumpPower = 10f;
    public GroundCheck groundCheck;

    private Vector3 motion = new Vector3();

	void Update () {
		if (Input.GetKey(KeyCode.D)) {
			motion.x += maxSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)) {
			motion.x -= maxSpeed * Time.deltaTime;
		}
        if (Input.GetKey(KeyCode.Space) && groundCheck.isGrounded()) {
            jump();
        }
		transform.Translate(motion);
        motion = new Vector3();
	}

    void jump() {
		Debug.Log("jumping");
		//rigidbody2D.AddForce(new Vector2(0, jumpPower));
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
    }
}
