using UnityEngine;
using System.Collections;

public class Utils {

	public static Vector2 Vector2Convert(Vector3 v) {
		return new Vector2(v.x, v.y);
	}

	public static void LookAt2D(Transform transform, Vector2 target) {
		Vector2 dir = target - Vector2Convert(transform.position);
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

    public static bool InLayerMask(int layer, int mask) {
        return ((mask >> layer) & 1) == 1;
    }
}
