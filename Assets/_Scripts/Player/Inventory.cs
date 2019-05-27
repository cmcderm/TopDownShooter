using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Item[][] _inv;

    public ItemManager _itemManager;

    [SerializeField]
    private int invSize = 8;

    [SerializeField]
    private int width = 4;
    [SerializeField]
    private int height = 4;

    void Start () {
        for(int i = 0; i < height; i++) {
            _inv[i] = new Item[width];
        }
    }
    
    //Get Item by description (find handgun ammo for reloading for example)
    Item GetItem(string desc){
        for(int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if(_inv[i][j] != null && _inv[i][j].name == desc){
                    return _inv[i][j];
                }
            }
        }
        return _itemManager.CreateItem(-1);
    }
    
    //Get Item by place in inventory (for when a clicked item is acted on)
    Item GetItem(int x, int y){
        if(_inv[x][y] != null){
            return _inv[x][y];
        } else {
            return _itemManager.CreateItem(-1);
        }
    }

    //Return true if successful, false if inventory full
    bool AddItem(Item item) {
        for(int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if(_inv[i][j] = null){
                    _inv[i][j] = item;
                    return true;
                }
            }
        }
        return false;
    }
	
    bool AddItem(int id, int quantity) {
        return AddItem(_itemManager.CreateItem(id, quantity));
    }

    void RemoveItem(Item item, int quantity) {
        for(int i = 0; i < height; i++){
            for(int j = 0; j < width; j++){
                if(_inv[i][j] != null && _inv[i][j].name == item.name){
                    _inv[i][j] = null;
                }
            }
        }
    }
    
    void RemoveItem(int x, int y){
        _inv[x][y] = null;
    }
}
