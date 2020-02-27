using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TopDownShooter.Inventory.Interfaces;

namespace TopDownShooter {
	public class InventoryLinq : IInventory {

		IEnumerable<InvItem> _data

		InvItem this[int x, int y] {
			return _data;
		}

		InvItem GetItem(int id, int quantity = 1) {
			
		}
	}
}
