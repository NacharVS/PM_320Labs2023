using System.ComponentModel.DataAnnotations;

namespace Editor.Core.Inventory;

public enum EquipmentSlot
{
    Helmet = 10,
    Body = 20,
    Legs = 30,
    [Display]
    RightHand = 40,
    LeftHand = 50
}