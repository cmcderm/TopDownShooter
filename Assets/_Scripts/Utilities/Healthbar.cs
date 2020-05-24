using UnityEngine;

public class Healthbar : BarFill {

	private IDamageable _damageable;
	private HealthManager _healthManager;

	new public void Start () {
		base.Start();

		_healthManager = GetComponentInParent<IDamageable>().GetHealthManager();
	}

	public void LateStart() {
		_healthManager = _damageable.GetHealthManager();
		Debug.Log(_healthManager.ToString());
		if(_healthManager != null) {
			Debug.Log("Got me a health manager");
			SetMaxValue(_healthManager.MaxHealth);
			_healthManager.tookDamage += UpdateHealthBar;
		}
	}

	public void UpdateHealthBar(int newHealth) {
		SetValue(newHealth);
	}
}