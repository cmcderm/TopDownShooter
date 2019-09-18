using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractType{
    item,
    door,
    button
}

public struct InteractResult {
    interactType type;
    bool success;
    InvItem item;
}
public interface Interactable {
    InteractResult interact();
}
