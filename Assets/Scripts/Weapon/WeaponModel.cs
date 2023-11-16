using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponModel/Weapon")]
public class WeaponModel : ScriptableObject
{
    [SerializeField] private int index;
    [SerializeField] private string nameWeapon;
    [SerializeField] public enum WeaponRangeType { Ranged, Melee };
    [Header("All")]
    [SerializeField] private WeaponRangeType rangeWeaponType;

    [SerializeField] public enum CanAim { Scope, NoScope };
    [SerializeField] private CanAim canAim;

    [SerializeField] public enum Crosshair { Circle, Small, Medium, Large };
    [SerializeField] private Crosshair crosshair;    

    [SerializeField] private GameObject weaponPrefab;

    [SerializeField] Animator animator;

    [SerializeField] private float fireRate;
    [SerializeField] private float weaponRange;

    [Header("Melle")]
    [SerializeField] private float smallDamage;
    [SerializeField] private float largeDamage;

    [SerializeField] public enum WeaponType { Pistol, Automate, Shotgun, Rifle };
    [Header("Range")]
    [SerializeField] private WeaponType weaponType;

    [SerializeField] public enum TypeFireRate { Auto, Semi };
    [SerializeField] private TypeFireRate typeFireRate;

    [SerializeField] private WeaponAmmoType weaponAmmoType;

    [SerializeField] private AmmoInventoryModel ammoModel;

    [SerializeField] private bool useSpread;
    [SerializeField] private float spreadFactor;

    [SerializeField] private int shotCount = 1;

    [SerializeField] private float rangedWeaponDamage;

    [SerializeField] private int ammoInWeapon;
    [SerializeField] private int maxAmmoInWeapon;

    public WeaponType GetWeaponType() => weaponType;
    public TypeFireRate GetTypeWeaponFireRate() => typeFireRate;
    public WeaponAmmoType GetWeaponAmmoType() => weaponAmmoType;
    public bool GetUseSpread() => useSpread;
    public float GetSpreadFactor() => spreadFactor;
    public int GetShotCount() => shotCount;
    public float GetRangeDamage() => rangedWeaponDamage;
    public int GetAmmoInWeapon() => ammoInWeapon;
    public int GetMaxAmmoInWeapon() => maxAmmoInWeapon;

    public void ReloadAmmoInWeapon(int value)
    {
        if (value < 0) return;
        if (value >= maxAmmoInWeapon) value = maxAmmoInWeapon;

        if (weaponAmmoType == WeaponAmmoType.Pistol)
        {
            if (ammoModel.GetCurrentPistolAmmo() == 0) return;
            if (ammoModel.GetCurrentPistolAmmo() >= maxAmmoInWeapon)
            {
                ammoModel.SubstractPistolAmmo(value);
                ammoInWeapon = maxAmmoInWeapon;
            }
            else if (ammoModel.GetCurrentPistolAmmo() >= value)
            {
                ammoInWeapon += value;
                ammoModel.SubstractPistolAmmo(value);                
            }
            else
            {
                ammoInWeapon += ammoModel.GetCurrentPistolAmmo();
                ammoModel.SubstractPistolAmmo(ammoModel.GetCurrentPistolAmmo());
            }
        }
        else if (weaponAmmoType == WeaponAmmoType.Automate)
        {
            if (ammoModel.GetCurrentAutomateAmmo() == 0) return;
            if (ammoModel.GetCurrentAutomateAmmo() >= maxAmmoInWeapon)
            {
                ammoModel.SubstractAutomateAmmo(value);
                ammoInWeapon = maxAmmoInWeapon;
            }
            else if (ammoModel.GetCurrentAutomateAmmo() >= value)
            {
                ammoInWeapon += value;
                ammoModel.SubstractAutomateAmmo(value);
            }
            else
            {
                ammoInWeapon += ammoModel.GetCurrentAutomateAmmo();
                ammoModel.SubstractAutomateAmmo(ammoModel.GetCurrentAutomateAmmo());
            }
        }
        else if (weaponAmmoType == WeaponAmmoType.Shotgun)
        {
            if (ammoModel.GetCurrentShotgunAmmo() == 0) return;
            if (ammoModel.GetCurrentShotgunAmmo() >= maxAmmoInWeapon)
            {
                ammoModel.SubstractShotgunAmmo(value);
                ammoInWeapon = maxAmmoInWeapon;
            }
            else if (ammoModel.GetCurrentShotgunAmmo() >= value)
            {
                ammoInWeapon += value;
                ammoModel.SubstractShotgunAmmo(value);
            }
            else
            {
                ammoInWeapon += ammoModel.GetCurrentShotgunAmmo();
                ammoModel.SubstractShotgunAmmo(ammoModel.GetCurrentShotgunAmmo());
            }
        }
    }

    public void RemoveAmmoInWeapon(int value)
    {
        if (value < 0 || value > 2) return;
        ammoInWeapon -= value;
    }
    public float GetSmallDamage() => smallDamage;
    public float GetLargeDamage() => largeDamage;

    public int GetweaponIndex() => index;
    public WeaponRangeType GetWeaponRangeType() => rangeWeaponType;
    public CanAim GetCanAim() => canAim;
    public Crosshair GetCrosshair() => crosshair;
    public Animator GetAminator() => animator;
    public GameObject GetWeaponPrefab() => weaponPrefab;
    public float GetFireRate() => fireRate;
    public float GetRange() => weaponRange;
}
