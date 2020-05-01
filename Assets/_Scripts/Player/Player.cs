using UnityEngine;
using TopDownShooter.Interactables;
using System;
using TopDownShooter.Inventory;

/// <summary>
/// Class to coordinate each of the functions of the player. e.g. Movement, Inventory, etc.
/// </summary>
[RequireComponent(typeof(TopDownPlayerController))]
[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(InventoryManager))]
public class Player : MonoBehaviour {

	public WeaponController _weaponCtrl;
	public TopDownPlayerController _playerCtrl;
	public InventoryManager _invMgr;

	void Start() {
		_weaponCtrl = GetComponent<WeaponController>();
		_playerCtrl = GetComponent<TopDownPlayerController>();
		_invMgr = GetComponent<InventoryManager>();

		// Subscribe to player events
		_playerCtrl.Interacted += HandleInteraction;
		_playerCtrl.ShowInventory += ShowInventory;
	}

	// TODO: Figure out how to potentially cancel picking up the item if the pickup failed
	// Option: begin pickup and delete the object, drop a new one onto the ground? Not excited about that one
	private void HandleInteraction(object sender, InteractResult result) {
		Debug.Log("Interacting!");
		if (result.success) {
			switch (result.type) {
				case InteractType.item:
					// Tasks:
					// Add it to the inventory and get back a response

					InvItem response = _invMgr.inventory.AddItem(result.item);
					// Check the response
					//  -If it's successfully added with no leftover, delete the object
					//  -If it succeeded, but there's leftover, update the object's count
					//  -If it failed, figure out why and maybe later we post a notification
					if (response.quantity == 0) {
						Debug.Log($"Item {result.item} has been picked up from {result.target.name}");
						Destroy(result.target);
					}
					else if (response.quantity > 0) {
						try {
							ItemPickup itemPickup = result.target.GetComponent<ItemPickup>();
							itemPickup.UpdateItem(response);
						} catch (Exception ex) {
							Debug.LogError("Error while updating item! " + ex.Message);
						}
					}
					// How is failure identified?
					break;
				case InteractType.door:
					Debug.Log("Door opened!");
					break;
				case InteractType.button:
					Debug.Log("Button pressed!");
					break;
			}
		}
		else {
			Debug.LogError("Interact Failed!");
		}
	}

	private void ShowInventory(object sender) {
		throw new NotImplementedException();
	}
}
