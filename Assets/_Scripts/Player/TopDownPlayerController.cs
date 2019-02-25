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
}
