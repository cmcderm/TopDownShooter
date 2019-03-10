using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Item[][] _inv;

    [SerializeField]
    private int invSize = 8;

    [SerializeField]
    private int width = 4;
    [SerializeField]
    private int height = 4;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < height; i++) {
            _inv[i] = new Item[width];
        }
	}

    void AddItem(Item item) {

    }
	
    void AddItem(int id, int quantity) {
        
    }

    void RemoveItem(Item item) {

    }

	// Update is called once per frame
	void Update () {
		
	}
}
