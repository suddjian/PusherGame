using UnityEngine;
using System.Collections;

public class PeeBag : MonoBehaviour, IHealthListener {

	void Start() {
		Health h = GetComponent<Health>();
		if (h != null) {
			h.addListener(this);
		}
	}

	public void HealthChangeEvent(Health h, float pre, float current) {
	}

	public void DeathEvent(Health h, float pre, float current) {
		Destroy(gameObject);
	}
}
