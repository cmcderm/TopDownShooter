using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownPlayerController : MonoBehaviour {

    //Values
    float moveSpeed = 8f;

    //Components
    Rigidbody2D _rigid;

	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        MouseLook();

        Move();

        CheckForInteractable();
    }

    void Move() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 moveNormal = new Vector2(x, y);
        if (moveNormal.magnitude > 1) {
            moveNormal = moveNormal.normalized;
            x = moveNormal.x;
            y = moveNormal.y;
        }
        _rigid.MovePosition(new Vector2(_rigid.position.x + (x * Time.deltaTime * moveSpeed), _rigid.position.y + (y * Time.deltaTime * moveSpeed)));
    }

    void MouseLook() {
        Vector3 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot;
    }

    void CheckForInteractable() {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");

        float closestDot = 0f;
        float newDot;
        GameObject closest;
        foreach (GameObject inter in interactables) {
            Debug.DrawRay(transform.position, inter.transform.position - transform.position);
            Debug.Log("Dot toward " + inter.name + " " + Mathf.Abs(Vector3.Dot(transform.right.normalized, (inter.transform.position - transform.position).normalized)));
            newDot = Vector3.Dot(transform.right.normalized, (inter.transform.position - transform.position).normalized);
            if (newDot > closestDot) {
                closestDot = newDot;
                closest = inter;
            }
        }
    }
}
