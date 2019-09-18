using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, Interactable {

    public float radius = 1f;

    public Item item { get; set; }

    void Start() {

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void interact() {
        Debug.Log("Interacted with " + gameObject.name);
    }


}
