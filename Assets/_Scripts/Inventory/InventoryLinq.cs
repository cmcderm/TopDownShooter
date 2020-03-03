using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TopDownShooter.Inventory;

namespace TopDownShooter.Inventory {
	public class InventoryLinq : IInventory {

		IEnumerable<InvItem> _data;

		public InventoryLinq(){
			_data = new List<InvItem>();
		}

		InvItem this[int x, int y] {
			get {
				return _data[x, y];
			}
		}

		InvItem GetItem(int id, int quantity = 1) {
			
		}
	}
}
