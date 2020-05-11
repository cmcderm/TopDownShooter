using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable {
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
            this.Break();
        }

        return hpLeft;
    }

    private void Break() {
        // Animate

        Destroy(gameObject);
    }
}
