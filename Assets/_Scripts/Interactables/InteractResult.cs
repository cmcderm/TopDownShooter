using TopDownShooter.Inventory;
using UnityEngine;

namespace TopDownShooter.Interactables {
    public class InteractResult {
        public InteractType type { get; set; }
        public bool success { get; set; }
        public InvItem item { get; set; }
        public GameObject target { get; set; }
    }
}
