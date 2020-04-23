using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Inventory.Interfaces;

public class InventoryManager : MonoBehaviour {

	[SerializeField]
	private GameObject UI;



	public IInventory inventory { get; protected set; }

	void Start() {
		if (!UI) {
			Debug.Log("Inventory Manager doesn't have a reference to a UI");
		}

		// This will have to have to initialize from save
		inventory = new Inventory();
	}

	public void ShowInventory() {
		if (UI) {
			//Show
			Debug.Log("Show UI");
		}
		else {
			Debug.LogError("No Reference to a UI Inventory Object!");
		}
		return;
	}
}
