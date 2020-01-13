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
        target = player?.transform ?? throw new System.Exception("Error, Camera not provided a player to watch.");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = newPos;
	}
}
