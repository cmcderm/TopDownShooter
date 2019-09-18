using UnityEngine;
using System.Collections;

public interface IInventory {

    InvItem GetItem(string desc);
    InvItem GetItem(int x, int y);
    bool AddItem(Item newItem, int newQuantity = 1);
    bool AddItem(int id, int itemQuantity);
    void RemoveItem(Item item, int numToRemove = 1);
    void RemoveItem(int x, int y);
}
