using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    private Dictionary<int, Item> _ItemDB;

	// Use this for initialization
	void Start () {
        //Need to implement loading item DB from directory of Scriptable Objects!
        _ItemDB = new Dictionary<int, Item>() {
            {-1, new Item{ itemID = -1, name = "No Item", icon = null, description = "You shouldn't see this... loligator made a mistake..."} }
        };

        _ItemDB.Add(1, new Item { itemID = 1, name = "Handgun", icon = null, description = "Standard issue 9mm handgun. It's better than nothing." } );
    }

    public Item CreateItem(int id) {
        return CreateItem(id, 1);
    }

    public Item CreateItem(int id, int q) {
        Item item = _ItemDB[id];

        Item newitem = new Item() {
            itemID = item.itemID,
            name = item.name,
            icon = item.icon
            
        };

        return newitem;
    }
}
