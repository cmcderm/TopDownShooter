using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Interactables;

[RequireComponent(typeof(TopDownPlayerController))]
[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(InventoryManager))]
public class Player : MonoBehaviour {

    public WeaponController _weaponCtrl;
    public TopDownPlayerController _playerCtrl;
    public InventoryManager _invMgr;

	void Start () {
        _weaponCtrl = GetComponent<WeaponController>();
        _playerCtrl = GetComponent<TopDownPlayerController>();
        _invMgr = GetComponent<InventoryManager>();

        // Subscribe to item pickup event
        _playerCtrl.Interacted += HandleInteraction;
	}
	
	void Update () {
		
	}

    // TODO: Figure out how to potentially cancel picking up the item if the pickup failed
    // Option: begin pickup and delete the object, drop a new one onto the ground? Not excited about that one
    void HandleInteraction(object sender, InteractResult item) {
        if (result.success) {
            switch (result.type) {
                case InteractType.item:
                    ItemPickup?.Invoke(this, result.item);
                    // TODO: Work on destroying the object after it's been added to inventory
                    // Question: How do we confirm it's been picked up after sending this event out?
                    // Are events the right tool for this? I like that additional scripts can choose to listen
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
}
