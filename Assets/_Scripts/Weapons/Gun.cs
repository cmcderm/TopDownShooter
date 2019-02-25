using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {

    public GameObject EndOfBarrel;
    public GameObject HoldPoint;

    abstract public void Fire();
    abstract public void Reload();
}

