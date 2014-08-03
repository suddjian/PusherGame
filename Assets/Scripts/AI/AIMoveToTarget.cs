using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MyCharacterController2D))]
public class AIMoveToTarget : MonoBehaviour {

	public Transform target;
	
	private MyCharacterController2D control;

	void Start() {
		control = GetComponent<MyCharacterController2D>();
	}

	void Update () {
		float dx = 0;
		if (transform.position.x < target.position.x) {
			dx = 1;
		} else if (transform.position.x > target.position.x) {
			dx = -1;
		}
		control.MoveHorizontal(dx * Time.deltaTime);
	}
}
