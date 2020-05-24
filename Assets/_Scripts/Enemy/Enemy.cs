using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {

	float sightRadius = 25f;

	bool debug = true;

	[SerializeField]
	private int StartingHealth;
	private HealthManager _hp;
	private BarFill HealthBar;

	void Start () {
		_hp = new HealthManager (StartingHealth);
	}

	public int GetHealthLeft () {
		return _hp.CurrentHealth;
	}

	public int TakeDamage (int amount) {
		int hpLeft = _hp.DecreaseHealth(amount);

		return hpLeft;
	}

	void Update () {
		RaycastHit2D[] inRange = Physics2D.CircleCastAll (transform.position, sightRadius, transform.forward, sightRadius, LayerMask.NameToLayer ("Player"));
		foreach (RaycastHit2D hit in inRange) {
			Debug.Log (hit.ToString ());
		}
	}
}
