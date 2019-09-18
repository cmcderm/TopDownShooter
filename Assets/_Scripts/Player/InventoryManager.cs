using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private GameObject UI;

    private IInventory inventory;

    void Start() {
        inventory = new Inventory();

        if(UI == null) {
            Debug.Log("Inventory Manager doesn't have a reference to a UI");
        }
    }

    public void ShowInventory() {
        if(UI) {
            //Show
            Debug.Log("Show UI");
        }
        else {
            Debug.LogError("No Reference to a UI Inventory Object!");
        }
        return;
    }
}
