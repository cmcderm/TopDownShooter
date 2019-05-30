using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownPlayerController : MonoBehaviour {

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
        interactFocus = CheckForInteractable();
	
        if(Input.GetKeyDown(KeyCode.E)){
		    interactFocus.interact();
        }
    }

    private void FixedUpdate() {
        Vector2 newPosition = Move();

        Look(newPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private Vector2 Move() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 moveNormal = new Vector2(x, y);
        if (moveNormal.magnitude > 1) {
            moveNormal = moveNormal.normalized;
            x = moveNormal.x;
            y = moveNormal.y;
        }

        Vector2 newPosition = new Vector2(_rigid.position.x + (x * Time.deltaTime * moveSpeed), _rigid.position.y + (y * Time.deltaTime * moveSpeed));
        _rigid.MovePosition(newPosition);

        return newPosition;
    }

    private void Look(Vector2 position, Vector2 target) {
        Vector3 lookDir = target - position;
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
