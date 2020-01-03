using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Interactables;
using TopDownShooter.Interactables.Interfaces;

public class ItemPickup : MonoBehaviour, IInteractable {

    public float radius = 1f;

    public Item item { get; set; }

    void Start() {

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public InteractResult interact() {
        Debug.Log("Interacted with " + gameObject.name);
        return new InteractResult {
            type = InteractType.item,
            success = true,
            item = new InvItem {
                item = item
            }
        };
    }
}
