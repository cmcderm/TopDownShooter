using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType {
    Item,
    Door
}

public interface Interactable {
    void interact();
}
