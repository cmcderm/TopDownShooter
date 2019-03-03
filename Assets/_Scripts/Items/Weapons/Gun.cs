using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, Item {

    public GameObject EndOfBarrel;
    public GameObject HoldPoint;

    abstract public void Fire();
    abstract public void Reload();
}

