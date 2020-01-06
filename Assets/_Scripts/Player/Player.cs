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
    void HandleInteraction(object sender, InteractResult result) {
        if (result.success) {
            switch (result.type) {
                case InteractType.item:
                    // Tasks:
                    // Add it to the inventory and get back a response
                    // Check the response
                    //  -If it's successfully added with no leftover, delete the object
                    //  -If it succeeded, but there's leftover, update the object's count
                    //  -If it failed, figure out why and maybe later we post a notification
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
