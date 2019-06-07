using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownPlayerController : MonoBehaviour {

    //Input
    Vector2 movement;

    //Values
    float moveSpeed = 8f;

    //Components
    Rigidbody2D _rigid;
    
    //Interactable
    Interactable interactFocus;

    void Start () {
        _rigid = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        Look(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        interactFocus = CheckForInteractable();
	
        if(Input.GetKeyDown(KeyCode.E)){
		    interactFocus.interact();
        }
    }

    private void FixedUpdate() {
        Move(movement);
    }

    private Vector2 Move(Vector2 movement) {
        float x, y;
        if (movement.magnitude > 1) {
            movement = movement.normalized;
            x = movement.x;
            y = movement.y;
        }

        Vector2 newPosition = new Vector2(_rigid.position.x + (movement.x * Time.deltaTime * moveSpeed), _rigid.position.y + (movement.y * Time.deltaTime * moveSpeed));
        _rigid.MovePosition(newPosition);

        return newPosition;
    }

    private void Look(Vector2 position, Vector2 target) {
        Vector3 lookDir = position - target;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot;

        Debug.DrawLine(transform.position, lookDir);
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
