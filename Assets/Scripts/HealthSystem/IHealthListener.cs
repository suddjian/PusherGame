using UnityEngine;
using System.Collections;

public interface IHealthListener {
	void HealthChangeEvent(Health h, float previousHealth, float currentHealth);
	void DeathEvent(Health h, float previousHealth, float currentHealth);
}
