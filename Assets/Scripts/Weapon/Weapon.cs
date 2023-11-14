using Player;
using System;
using UnityEngine;
using static WeaponModel;

public class Weapon : MonoBehaviour
{
    public static Action weaponShoted;

    [SerializeField] private WeaponModel model;
    [SerializeField] private bool inHand;

    public void SetWeaponModel(WeaponModel model) => this.model = model;
    public WeaponRangeType GetWeaponRangeType() => WeaponRangeType.Ranged;
    public GameObject GetWeaponPrefab() => this.gameObject;
    public int GetCurrentAmmoInWeapon() => 0;
    public WeaponAmmoType GetWeaponAmmoUseType() => WeaponAmmoType.Pistol;
    private void OnEnable()
    {
        if (model.GetWeaponRangeType() == WeaponRangeType.Melee) 
        {
            InputManager.smallWeaponAttakButtonCliked += SmallDamageAttak;
            InputManager.largeweaponAttakButtonCliked += LargeDamageAttak;
        }
        else if (model.GetWeaponRangeType() == WeaponRangeType.Ranged) 
        {
            if (model.GetTypeWeaponFireRate() == TypeFireRate.Auto)
                InputManager.autoFireButtonCliked += Shot;
            else if (model.GetTypeWeaponFireRate() == TypeFireRate.Semi)
                InputManager.semiFireButtonCliked += Shot;
            InputManager.aimButtonCliked += TakeAim;
            InputManager.weaponRealodButtonCliked += Reload;
        }
    }

    private void OnDisable()
    {
        if (model.GetWeaponRangeType() == WeaponRangeType.Melee)
        {
            InputManager.smallWeaponAttakButtonCliked -= SmallDamageAttak;
            InputManager.largeweaponAttakButtonCliked -= LargeDamageAttak;
        }
        else if (model.GetWeaponRangeType() == WeaponRangeType.Ranged)
        {
            if (model.GetTypeWeaponFireRate() == TypeFireRate.Auto)
                InputManager.autoFireButtonCliked -= Shot;
            else if (model.GetTypeWeaponFireRate() == TypeFireRate.Semi)
                InputManager.semiFireButtonCliked -= Shot;
            InputManager.aimButtonCliked -= TakeAim;
            InputManager.weaponRealodButtonCliked -= Reload;
        }
    }

    private void SmallDamageAttak()
    {

    }

    private void LargeDamageAttak() 
    {

    }

    private void Shot()
    {
        if (!inHand)
        {
            //ammoInWeapon--;
            weaponShoted?.Invoke();
        }
    }

    private void TakeAim()
    {

    }

    private void Reload()
    {
        //ammoInWeapon = maxAmmoInWeapon;
        //ammoModel.SubstractPistolAmmo(maxAmmoInWeapon);
    }
}
