using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform target;
	public Vector2 deadZoneTopLeft = Vector2.zero;
	public Vector2 deadZoneBottomRight = Vector2.zero;
	public float followSpeed = 0.3f; // between 0 and 1

	void Update () {
		/*
		Vector3 movement = Vector3.zero;
		float left = transform.position.x + deadZoneTopLeft.x;
		float right = transform.position.x + deadZoneBottomRight.x;
		float top = transform.position.y + deadZoneTopLeft.y;
		float bottom = transform.position.y + deadZoneBottomRight.y;

		if (target.transform.position.x < left) {
			movement.x = target.transform.position.x - left;
		} else if (target.transform.position.x > right) {
			movement.x = target.transform.position.x - right;
		}
		if (target.transform.position.y < bottom) {
			movement.y = target.transform.position.y - bottom;
		} else if (target.transform.position.y > top) {
			movement.y = target.transform.position.y - top;
		}
		transform.position = transform.position + movement;
		*/
		Vector3 newPos = (target.transform.position - transform.position) * followSpeed * Time.deltaTime;
		newPos.z = 0;
		transform.position += newPos;
	}
	
	void OnDrawGizmos() {

	}
}
