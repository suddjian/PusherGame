using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {

	public float maxHealth = 10;
	public float deathPoint = -100;

	private LinkedList<IHealthListener> listeners = new LinkedList<IHealthListener>();

	private float health;
	public float CurrentHealth {
		get {
			return health;
		}
	}

	void Start() {
		health = maxHealth;
	}

	void Update () {
		if (health <= 0 || transform.position.y <= deathPoint) {
			Die();
		}
	}

	public void ApplyDamage(float dmg = 1.0f) {
		float oldHealth = health;
		health -= dmg;
		foreach (IHealthListener hl in listeners) {
			hl.HealthChangeEvent(this, oldHealth, health);
		}
	}

	public void Die() {
		float oldHealth = health;
		health = 0;
		foreach (IHealthListener hl in listeners) {
			hl.DeathEvent(this, oldHealth, health);
		}
	}

	public void addListener(IHealthListener hl) {
		listeners.AddFirst(hl);
	}

	public static void ApplyDamage(Component c, float dmg = 1.0f) {
		ApplyDamage(c.gameObject);
	}

	public static void ApplyDamage(GameObject o, float dmg = 1.0f) {
		Health h = o.GetComponent<Health>();
		if (h != null) {
			h.ApplyDamage(dmg);
		}
	}

	public static void Die(Component c) {
		Die (c.gameObject);
	}

	public static void Die(GameObject o) {
		Health h = o.GetComponent<Health>();
		if (h != null) {
			h.Die();
		}
	}
}
