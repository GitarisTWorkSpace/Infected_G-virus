using UnityEngine;
[CreateAssetMenu(fileName = "WeaponInventory", menuName = "Inventory/WeaponInventory")]
public class WeaponInventoryModel : ScriptableObject
{
    [SerializeField] private WeaponModel[] weapons;

    public WeaponModel[] GetAllWeaponInInventory() => weapons;

    public WeaponModel GetWeaponByIndex(int index)
    {
        if (index >= weapons.Length) return null;
        return weapons[index];
    }

    public void AddWeaponInInventory(int index, WeaponModel weapon)
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
