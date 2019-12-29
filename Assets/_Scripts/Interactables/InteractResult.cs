using TopDownShooter.Inventory;

namespace TopDownShooter.Interactables {
    public struct InteractResult {
        InteractType type;
        bool success;
        InvItem item;
    }
}
