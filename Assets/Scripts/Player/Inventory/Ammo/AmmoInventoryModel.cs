using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Ammo", menuName = "Inventory/Ammo")]
public class AmmoInventoryModel : ScriptableObject
{
    public static Action changedAmmoInInventory;

    [SerializeField] private int pistolAmmo;
    [SerializeField] private int maxPistolAmmo;
    [SerializeField] private int automateAmmo;
    [SerializeField] private int maxAutomateAmmo;
    [SerializeField] private int shotgunAmmo;
    [SerializeField] private int maxShotgunAmmo;

    public int GetCurrentPistolAmmo() => pistolAmmo;
    public int GetMaxPistolAmmo() => maxPistolAmmo;

    public int GetCurrentAutomateAmmo() => automateAmmo;
    public int GetMaxAutomateAmmo() => maxAutomateAmmo;

    public int GetCurrentShotgunAmmo() => shotgunAmmo;
    public int GetMaxShotgunAmmo() => maxShotgunAmmo;

    public void AddPistolAmmo(int value)
    {
        if (value < 0) return;
        pistolAmmo += value;
        if (pistolAmmo > maxPistolAmmo) pistolAmmo = maxPistolAmmo;
        changedAmmoInInventory?.Invoke();
    }

    public void SubstractPistolAmmo(int value)
    {
        if (value < 0) return;
        pistolAmmo -= value;
        if (pistolAmmo < 0) pistolAmmo = 0;
        changedAmmoInInventory?.Invoke();
    }

    public void AddAutomateAmmo(int value)
    {
        if (value < 0) return;
        automateAmmo += value;
        if (automateAmmo > maxAutomateAmmo) automateAmmo = maxAutomateAmmo;
        changedAmmoInInventory?.Invoke();
    }

    public void SubstractAutomateAmmo(int value)
    {
        if (value < 0) return;
        automateAmmo -= value;
        if (automateAmmo < 0) automateAmmo = 0;
        changedAmmoInInventory?.Invoke();
    }

    public void AddShotgunAmmo(int value)
    {
        if (value < 0) return;
        shotgunAmmo += value;
        if (shotgunAmmo > maxShotgunAmmo) shotgunAmmo = maxShotgunAmmo;
        changedAmmoInInventory?.Invoke();
    }

    public void SubstractShotgunAmmo(int value)
    {
        if (value < 0) return;
        shotgunAmmo -= value;
        if (shotgunAmmo < 0) shotgunAmmo = 0;
        changedAmmoInInventory?.Invoke();
    }
}
