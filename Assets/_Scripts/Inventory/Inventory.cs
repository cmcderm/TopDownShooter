using System;
using System.Collections.Generic;
using UnityEngine;

using TopDownShooter.Inventory.Interfaces;
using System.Collections;

namespace TopDownShooter.Inventory {

	public class Inventory : IInventory, IEnumerable<InvItem> {
		public InvItem[,] _data;

		public InvItem this[int x, int y] {
			get {
				return _data[x, y];
			}
		}

		[SerializeField]
		private int width = 4;
		[SerializeField]
		private int height = 4;

		public Inventory() {
			_data = new InvItem[width, height];
		}

		//Get Item by description (find handgun ammo for reloading for example)
		public InvItem GetItem(int id, int quantity = 1) {
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					if (_data[i, j].item.itemID == id) {
						return _data[i, j];
					}
				}
			}
			return new InvItem { item = null, quantity = 0 };
		}

		//Get Item by place in inventory (for when a clicked item is acted on)
		public InvItem GetItem(int x, int y, int quantity = 1) {
			if (_data[x, y].item != null) {
				return _data[x, y];
			}
			else {
				return new InvItem { item = null, quantity = quantity };
			}
		}

		public InvItem AddItem(InvItem newItem) {
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					if (newItem.quantity == 0) return newItem;

					if (_data[i, j] == null) {
						_data[i, j] = newItem;
						return new InvItem {
							item = newItem.item,
							quantity = 0
						};
					}
					else if(_data[i, j].item == newItem.item){
						while(_data[i, j].quantity < _data[i, j].item.maxQuantity && newItem.quantity > 0) {
							_data[i, j].quantity++;
							newItem.quantity--;
						}
					}
				}
			}
			return newItem;
		}

		public InvItem AddItem(Item newItem, int newQuantity = 1) {
			return AddItem(new InvItem {
				item = newItem,
				quantity = newQuantity
			});
		}

		public InvItem AddItem(int id, int itemQuantity = 1) {
			throw new NotImplementedException();
			//return AddItem(new InvItem {
			//    item = new Item(id), quantity = itemQuantity
			//});
		}

		public InvItem RemoveItem(Item item, int numToRemove = 0) {
			InvItem deleted = new InvItem { item = null, quantity = 0 };
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					if (String.Equals(_data[i, j].item?.itemID, item.itemID)) {
						deleted = _data[i, j];
						_data[i, j] = new InvItem { item = null, quantity = 0 };
					}
				}
			}
			return deleted;
		}

		public InvItem RemoveItem(int x, int y) {
			InvItem deleted = _data[x, y];
			_data[x, y] = new InvItem { item = null, quantity = 0 };
			return deleted;
		}

		public IEnumerator<InvItem> GetEnumerator() {
			return EnumerateItems().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		private IEnumerable<InvItem> EnumerateItems() {
			for (int i = 0; i < _data.GetLength(0); i++) {
				for (int j = 0; j < _data.GetLength(1); j++) {
					yield return _data[i, j];
				}
			}
		}
	}
}
