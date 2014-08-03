using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Health health;
	public Vector2 position = new Vector2(10, 10);
	public Vector2 size = new Vector2(100, 10);
	public Color goodColor = Color.green;
	public Color badColor = Color.red;
	public Texture2D texture;

	void OnGUI() {
		GUI.Box(new Rect(position.x, position.y, size.x * health.CurrentHealth / health.maxHealth, size.y), "");
	}
}
