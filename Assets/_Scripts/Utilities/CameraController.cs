using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject player;

    private Transform target;

    // Use this for initialization
    void Start () {
        target = player?.transform ?? throw new ArgumentNullException();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(target?.position.x ?? 0, target?.position.y ?? 0, transform.position.z);
        transform.position = newPos;
	}
}
