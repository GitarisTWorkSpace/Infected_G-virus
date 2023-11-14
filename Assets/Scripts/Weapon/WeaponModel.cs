using UnityEngine;

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

    [SerializeField] private float rangedWeaponDamage;

    [SerializeField] private int ammoInWeapon;
    [SerializeField] private int maxAmmoInWeapon;

    public WeaponType GetWeaponType() => weaponType;
    public TypeFireRate GetTypeWeaponFireRate() => typeFireRate;
    public WeaponAmmoType GetWeaponAmmoType() => weaponAmmoType;
    public float GetRangeDamage() => rangedWeaponDamage;
    public int GetAmmoInWeapon() => ammoInWeapon;
    public int GetMaxAmmoInWeapon() => maxAmmoInWeapon;

    public void AddAmmoInWeapon(int value)
    {
        if (value < 0) return;
        if (value >= maxAmmoInWeapon) ammoInWeapon = maxAmmoInWeapon;
        else ammoInWeapon += value;
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
    public GameObject GetWeaponPrefab() => weaponPrefab;
    public float GetFireRate() => fireRate;
    public float GetRange() => weaponRange;
}
