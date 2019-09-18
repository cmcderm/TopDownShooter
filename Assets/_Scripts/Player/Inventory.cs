using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InvItem {
    public Item item;
    public int quantity;
}

public class Inventory : IInventory {

    private InvItem[][] _inv;

    [SerializeField]
    private int width = 4;
    [SerializeField]
    private int height = 4;

    void Start () {
        for(int i = 0; i < height; i++) {
            _inv[i] = new InvItem[width];
            for (int j = 0; j < width; i++){
                _inv[i][j] = new InvItem { item = null, quantity = 0 };
            }
        }
    }
    
    //Get Item by description (find handgun ammo for reloading for example)
    public InvItem GetItem(String desc){
        for(int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if(String.Equals(_inv[i][j].item.name, desc)){
                    return _inv[i][j];
                }
            }
        }
        return new InvItem { item = null, quantity = 0 };
    }
    
    //Get Item by place in inventory (for when a clicked item is acted on)
    public InvItem GetItem(int x, int y){
        if (_inv[x][y].item != null) {
            return _inv[x][y];
        } else {
            return new InvItem { item = null, quantity = 0 };
        }
    }

    //Return true if successful, false if inventory full
    public bool AddItem(Item newItem, int newQuantity = 1) {
        for(int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if (_inv[i][j].item = null) {
                    _inv[i][j] = new InvItem { item = newItem, quantity = 1 };
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
        for(int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if(String.Equals(_inv[i][j].item?.itemID, item.itemID)){
                    _inv[i][j] = new InvItem { item = null, quantity = 0 };
                }
            }
        }
    }
    
    public void RemoveItem(int x, int y){
        _inv[x][y] = new InvItem { item = null, quantity = 0 };
    }
}
