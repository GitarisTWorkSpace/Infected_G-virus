using UnityEngine;
[CreateAssetMenu(fileName = "WeaponInventory", menuName = "Inventory/WeaponInventory")]
public class WeaponInventoryModel : ScriptableObject
{
    [SerializeField] private Weapon[] weapons;

    public Weapon[] GetAllWeaponInInventory() => weapons;

    public Weapon GetWeaponByIndex(int index)
    {
        if (index >= weapons.Length) return null;
        return weapons[index];
    }

    public void AddWeaponInInventory(int index, Weapon weapon)
    {
        if (index >= weapons.Length) return;
        weapons[index] = weapon;
    }

    public void RemoveWeaponInInventory(int index)
    {
        if (index >= weapons.Length) return;
        weapons[index] = null;
    }
}
