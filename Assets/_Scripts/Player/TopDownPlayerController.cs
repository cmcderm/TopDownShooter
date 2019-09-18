using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InventoryManager))]
public class TopDownPlayerController : MonoBehaviour {

    // Values
    float moveSpeed = 8f;

    // Components
    Rigidbody2D _rigid;
    
    // Component
    Interactable interactFocus;
    InventoryManager inventoryManager;

    Vector2 move = new Vector2();
    Vector2 mouse = new Vector2();

    void Start () {
        _rigid = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        mouse.x = Input.mousePosition.x;
        mouse.y = Input.mousePosition.y;

        interactFocus = CheckForInteractable();
	
        if(Input.GetKeyDown(KeyCode.E)){
		    interactFocus.interact();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            inventoryManager.ShowInventory();
        }
    }

    void FixedUpdate() {
        MouseLook(mouse);
        Move(move);
    }

    private void Move(Vector2 move) {
        Vector2 moveNormal = move;
        if (moveNormal.magnitude > 1) {
            moveNormal = moveNormal.normalized;
        }
        _rigid.MovePosition(new Vector2(
            _rigid.position.x + (moveNormal.x * Time.deltaTime * moveSpeed),
            _rigid.position.y + (moveNormal.y * Time.deltaTime * moveSpeed)
        ));
    }

    private void MouseLook(Vector2 mouse) {
        Vector3 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot;
    }

    private Interactable CheckForInteractable() {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");

        float closestDot = 0f;
        float newDot;
        GameObject closest = null;
        foreach (GameObject inter in interactables) {
            //Debug.DrawRay(transform.position, inter.transform.position - transform.position);
            //Debug.Log("Dot toward " + inter.name + " " + Mathf.Abs(Vector3.Dot(transform.right.normalized, (inter.transform.position - transform.position).normalized)));
            newDot = Vector3.Dot(transform.right.normalized, (inter.transform.position - transform.position).normalized);
            if (newDot > closestDot) {
                closestDot = newDot;
                closest = inter;
            }
        }
        if(closest != null){
            Debug.Log("Selecting interactable: " + closest.name);
            return closest.GetComponent<Interactable>();
        } else {
            return null;
        }
    }
}
