using UnityEngine;

public class Healthbar : BarFill {

	private HealthManager _healthManager;

	new public void Start () {
		base.Start();

		_damageable = GetComponentInParent<Damageable>();
	}

	public void OnEnable() {
		_healthManager = _damageable.GetHealthManager();
		Debug.Log(_healthManager.ToString());
		if(_healthManager != null) {
			Debug.Log("Got me a health manager");
			SetMaxValue(_healthManager.MaxHealth);
			_healthManager.tookDamage += UpdateHealthBar;
		} else {
			Debug.Log("I didn't get me a fuckin health manager");
		}
	}

	public void UpdateHealthBar(int newHealth) {
		SetValue(newHealth);
	}
}