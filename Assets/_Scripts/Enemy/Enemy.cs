using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float sightRadius = 25f;

    bool debug = true;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        RaycastHit2D[] inRange = Physics2D.CircleCastAll(transform.position, sightRadius, transform.forward, sightRadius, LayerMask.NameToLayer("Player"));
        foreach(RaycastHit2D hit in inRange) {
            Debug.Log(hit.ToString());
        }
	}
}
