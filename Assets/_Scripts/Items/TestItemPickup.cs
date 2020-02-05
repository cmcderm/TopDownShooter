using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Interactables;
using TopDownShooter.Interactables.Interfaces;

[RequireComponent(typeof(SpriteRenderer))]
public class TestItemPickup : MonoBehaviour, IInteractable {

    public float radius = 1f;

    public Item item;

    private SpriteRenderer _spriteRenderer;

    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (item.icon) {
            Debug.Log("I have an icon!");
        }
        _spriteRenderer.sprite = item.icon;
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
