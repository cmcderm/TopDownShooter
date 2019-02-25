using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerController))]
[RequireComponent(typeof(WeaponController))]
public class Player : MonoBehaviour {
    public static Player p;

    public WeaponController wc;
    public TopDownPlayerController tdpc; //Good naming, I know thanks

	// Use this for initialization
	void Start () {
        if (!p) {
            p = this;
        } else {
            GameObject.Destroy(gameObject);
        }
        wc = GetComponent<WeaponController>();
        tdpc = GetComponent<TopDownPlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
