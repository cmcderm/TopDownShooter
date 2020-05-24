using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
	int TakeDamage (int amount);
	int GetHealthLeft ();
	HealthManager GetHealthManager();
}
