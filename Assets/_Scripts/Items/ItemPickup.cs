using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Interactables;
using TopDownShooter.Interactables.Interfaces;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemPickup : MonoBehaviour, IInteractable {

	public float radius = 1f;

	[SerializeField]
	private Item item;

	[SerializeField]
	private int quantity = 1;

	public InvItem invItem;

	private SpriteRenderer _spriteRenderer;

	void Start() {
		if(item == null || quantity == 0) {
			Destroy(gameObject);
		}
		else {
			invItem = new InvItem {
				item = item,
				quantity = quantity
			};
		}

		_spriteRenderer = GetComponent<SpriteRenderer>();

		if (invItem.item.icon) {
			_spriteRenderer.sprite = invItem.item.icon;
		}
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
			item = invItem,
			target = gameObject
		};
	}

	public void UpdateItem(InvItem update) {
		invItem = update;
	}
}
