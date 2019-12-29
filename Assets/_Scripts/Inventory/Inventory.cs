using System;
using UnityEngine;

using Assets._Scripts.Inventory.Interfaces;

namespace Assets._Scripts.Inventory {

    public class Inventory : IInventory {
        public InvItem[][] Data { get; }

        [SerializeField]
        private int width = 4;
        [SerializeField]
        private int height = 4;

        void Start() {
            for (int i = 0; i < height; i++) {
                Data[i] = new InvItem[width];
                for (int j = 0; j < width; i++) {
                    Data[i][j] = new InvItem { item = null, quantity = 0 };
                }
            }
        }

        //Get Item by description (find handgun ammo for reloading for example)
        public InvItem GetItem(int id, int quantity = 1) {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (Data[i][j].item.itemID == id) {
                        return Data[i][j];
                    }
                }
            }
            return new InvItem { item = null, quantity = 0 };
        }

        //Get Item by place in inventory (for when a clicked item is acted on)
        public InvItem GetItem(int x, int y, int quantity = 1) {
            if (Data[x][y].item != null) {
                return Data[x][y];
            }
            else {
                return new InvItem { item = null, quantity = quantity};
            }
        }

        //Return true if successful, false if inventory full
        public bool AddItem(Item newItem, int newQuantity = 1) {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (Data[i][j].item = null) {
                        Data[i][j] = new InvItem { item = newItem, quantity = 1 };
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddItem(int id, int itemQuantity) {
            throw new NotImplementedException();
            //return AddItem(new InvItem {
            //    item = new Item(id), quantity = itemQuantity
            //});
        }

        public void RemoveItem(Item item, int numToRemove = 0) {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (String.Equals(Data[i][j].item?.itemID, item.itemID)) {
                        Data[i][j] = new InvItem { item = null, quantity = 0 };
                    }
                }
            }
        }

        public void RemoveItem(int x, int y) {
            Data[x][y] = new InvItem { item = null, quantity = 0 };
        }
    }
}
