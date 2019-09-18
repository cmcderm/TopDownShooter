using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerController))]
[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(InventoryManager))]
public class Player : MonoBehaviour {
    public WeaponController _weaponCtrl;
    public TopDownPlayerController _playerCtrl;
    public InventoryManager _invMgr;

	// Use this for initialization
	void Start () {
        _weaponCtrl = GetComponent<WeaponController>();
        _playerCtrl = GetComponent<TopDownPlayerController>();
        _invMgr = GetComponent<InventoryManager>();

        // Subscribe to item pickup event
        _invMgr.ItemPickup += HandlePickup;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // TODO: Figure out how to potentially cancel picking up the item if the pickup failed
    // Option: begin pickup and delete the object, drop a new one onto the ground? Not excited about that one
    void HandlePickup(object sender, InvItem item) {
        _invMgr.AddItem(InvItem);
    }
}
