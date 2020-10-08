using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
	private HealthManager _hp;

	[SerializeField]
	private int StartingHealth;

	public void Start () {
		_hp = new HealthManager (StartingHealth);
	}

	public int GetHealthLeft () {
		return _hp.MaxHealth;
	}

	public int TakeDamage (int amount) {
		int hpLeft = _hp.DecreaseHealth (amount);

		if (_hp.isDead) {
			Dead ();
		}

		return hpLeft;
	}

	private void Dead () {
		// Animate
		Destroy (gameObject);
	}

	public HealthManager GetHealthManager () {
		Debug.Log("I gave my health manager");
		return _hp;
	}
}
