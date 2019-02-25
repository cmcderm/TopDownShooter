using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    Transform _player;

	// Use this for initialization
	void Start () {
        if (!_player) {
            _player = Player.p.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        transform.position = newPos;
	}
}
