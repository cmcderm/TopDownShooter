using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager {
	private int _maxHealth { get; set; }
	private int _currentHealth { get; set; }

	public int MaxHealth { get { return _maxHealth; } }
	public int CurrentHealth { get { return _currentHealth; } }

	public delegate void HealthEvent(int newHealth);
	public event HealthEvent tookDamage;

	[SerializeField]
	public BarFill _healthBar;

	public bool isDead {
		get {
			return _currentHealth <= 0;
		}
	}

	public HealthManager(int startHealth) {
		_maxHealth = startHealth;
		_currentHealth = _maxHealth;
	}

	/// <summary>
	/// Sets current health to the given amount or MaxHealth, whichever is greater.
	/// </summary>
	/// <param name="newHealth"></param>
	/// <returns></returns>
	public int SetHealth (int newHealth) {
		if(newHealth >= _maxHealth) {
			_currentHealth = _maxHealth;
		} else if (newHealth < _maxHealth) {
			_currentHealth = newHealth;
		}
		
		return _currentHealth;
	}

	public int IncreaseHealth (int inc) {
		return SetHealth (_currentHealth + inc);
	}

	public int DecreaseHealth (int dec) {
		return SetHealth (_currentHealth - dec);
	}
}
