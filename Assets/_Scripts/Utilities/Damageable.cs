using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

    private HealthManager _hp;

    private int StartingHealth;

    void Start() {
        
    }

    void Update() {
        
    }

    public void TakeDamage(int amount) {
        int hpLeft = _hp.DecreaseHealth(amount);

        if (_hp.isDead) {
            
        }
    }

    private void Dead() {
        
    }
}
