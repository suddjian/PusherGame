using UnityEngine;
using System.Collections;

public class Utils {

	public const string MSG_APPLY_DMG = "ApplyDamage";
	public const string MSG_DIE = "Die";

	public const string TAG_PLAYER = "Player";

	public static Vector2 Vec3to2(Vector3 v) {
		return new Vector2(v.x, v.y);
	}
	public static Vector3 Vec2to3(Vector2 v) {
		return new Vector3(v.x, v.y, 0);
	}

	public static void LookAt2D(Transform transform, Vector2 target) {
		Vector2 dir = target - Vec3to2(transform.position);
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

    public static bool InLayerMask(int layer, int mask) {
        return ((mask >> layer) & 1) == 1;
    }
}
