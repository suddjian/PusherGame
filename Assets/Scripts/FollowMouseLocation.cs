using UnityEngine;
using System.Collections;

public class FollowMouseLocation : MonoBehaviour {
	
	void Update () {
        float z = transform.position.z;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, z);
	}
}
