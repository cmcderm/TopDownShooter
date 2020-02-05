using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Inventory.Interfaces;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private GameObject UI;

    

    public IInventory inventory { get; protected set; }

    void Start() {
        if(!UI) {
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
