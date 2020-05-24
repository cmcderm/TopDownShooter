using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable {
	private HealthManager _hp;

	[SerializeField]
	private int StartingHealth;

	private BarFill healthBar;

	public void Start () {
		_hp = new HealthManager (StartingHealth);
		healthBar = GetComponentInChildren<BarFill>();
		if(healthBar) {
			healthBar.SetMaxHealth(StartingHealth);
		}
	}

	public int GetHealthLeft () {
		return _hp.MaxHealth;
	}

	public int TakeDamage (int amount) {
		int hpLeft = _hp.DecreaseHealth (amount);

		if(healthBar) {
			healthBar.SetHealth(hpLeft);
		}

		if (_hp.isDead) {
			Dead ();
		}

		return hpLeft;
	}

	private void Dead () {
		// Animate

		Destroy (gameObject);
	}
}
