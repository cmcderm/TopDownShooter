using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    Gun currWeapon;

	void Start () {
        SetGun(transform.GetComponentInChildren<Gun>());
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            currWeapon.Fire();
        }
        Debug.DrawRay(transform.position, transform.right * 20f, Color.red);
    }

    void SetGun(Gun newGun) {
        currWeapon = transform.GetComponentInChildren<Gun>();

        newGun.transform.localPosition = Vector3.zero - newGun.HoldPoint.transform.localPosition;
    }
}
