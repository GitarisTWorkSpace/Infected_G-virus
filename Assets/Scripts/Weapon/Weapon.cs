using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Action weaponShoted;
    [SerializeField] public enum RangeWeaponType { Ranged, Melee };
    [SerializeField] private RangeWeaponType rangeWeaponType;

    [SerializeField] public enum WeaponType { Pistol, Automate, Shotgun, Rifle };
    [SerializeField] private WeaponType weaponType;

    [SerializeField] public enum TypeFireRate { Auto, Semi };
    [SerializeField] private TypeFireRate typeFireRate;

    [SerializeField] public enum CanAim { Scope, NoScope };
    [SerializeField] private CanAim canAim;

    [SerializeField] public enum Crosshair { Circle , Small,  Medium, Large };
    [SerializeField] private Crosshair crosshair;

    [SerializeField] private WeaponAmmoType weaponAmmoType;

    [SerializeField] private Vector3 positionInHand; 

    [SerializeField] private AmmoInventoryModel ammoModel;

    [SerializeField] private float smallDamage;
    [SerializeField] private float largeDamage;

    [SerializeField] private float rangedWeaponDamage;
    [SerializeField] private float fireRate;
    [SerializeField] private float weaponRange;
    [SerializeField] private int ammoInWeapon;
    [SerializeField] private int maxAmmoInWeapon;

    public WeaponAmmoType GetWeaponAmmoUseType() => weaponAmmoType;

    public RangeWeaponType GetWeaponRangeType() => rangeWeaponType;

    public Vector3 GetPositionInHand() => positionInHand;
    public int GetCurrentAmmoInWeapon() => ammoInWeapon;

    private void OnEnable()
    {
        InputManager.fireButtonCliked += Shot;
        InputManager.weaponRealodButtonCliked += Reload;
    }

    private void OnDisable()
    {
        InputManager.fireButtonCliked -= Shot;
        InputManager.weaponRealodButtonCliked -= Reload;
    }

    private void SmallDamageAttak()
    {

    }

    private void LargeDamageAttak() 
    {

    }

    private void Shot()
    {
        ammoInWeapon--;
        weaponShoted?.Invoke();
    }

    private void TakeAim()
    {

    }

    private void Reload()
    {
        ammoInWeapon = maxAmmoInWeapon;
        ammoModel.SubstractPistolAmmo(maxAmmoInWeapon);
    }
}
