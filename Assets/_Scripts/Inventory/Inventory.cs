using System;
using UnityEngine;

using TopDownShooter.Inventory.Interfaces;

namespace TopDownShooter.Inventory {

    public class Inventory : IInventory {
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

        void Start() {
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
                return new InvItem { item = null, quantity = quantity};
            }
        }

        /// <summary>
        /// Adds item and returns leftover if any, otherwise returns null item
        /// </summary>
        /// <remarks>
        /// Returns items as is if inventory full
        /// </remarks>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public InvItem AddItem(InvItem newItem) {
            return newItem;
        }

        public InvItem AddItem(Item newItem, int newQuantity = 1) {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (_data[i, j].item = null) {
                        _data[i, j] = new InvItem { item = newItem, quantity = 1 };
                        return _data[i, j];
                    }
                }
            }
            return new InvItem { item = null, quantity = 0 };
        }

        public InvItem AddItem(int id, int itemQuantity) {
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
    }
}
