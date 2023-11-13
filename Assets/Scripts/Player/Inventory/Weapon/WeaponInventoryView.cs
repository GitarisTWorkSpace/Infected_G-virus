using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventoryView : MonoBehaviour
{
    [SerializeField] private WeaponInventoryModel weaponInventoryModel;
    [SerializeField] private AmmoInventoryModel ammoInventoryModel;

    [SerializeField] private TMP_Text ammoInInventoryText;
    [SerializeField] private Image weaponUseAmmo;
    [SerializeField] private Sprite[] ammoSprites;
    [SerializeField] private TMP_Text ammoInWeaponText;

    Weapon weaponInHand;

    private void OnEnable()
    {
        WeaponInventoryController.swichedWeaponInHands += ChangeWeaponInfo;
        AmmoInventoryModel.changedAmmoInInventory += ChangeAmmoInInventoryInfo;
        Weapon.weaponShoted += ChangeAmmoInWeaponInfo;
    }

    private void OnDisable()
    {
        WeaponInventoryController.swichedWeaponInHands -= ChangeWeaponInfo;
        AmmoInventoryModel.changedAmmoInInventory -= ChangeAmmoInInventoryInfo;
        Weapon.weaponShoted -= ChangeAmmoInWeaponInfo;
    }

    private void ChangeWeaponInfo(int indexWeapon)
    {
        weaponInHand = weaponInventoryModel.GetWeaponByIndex(indexWeapon);
        if (weaponInHand != null)
        {
            if (weaponInHand.GetWeaponRangeType() == Weapon.RangeWeaponType.Ranged)
            {
                weaponUseAmmo.gameObject.SetActive(true);
                if (weaponInHand.GetWeaponAmmoUseType() == WeaponAmmoType.Pistol)
                    weaponUseAmmo.sprite = ammoSprites[0];
                else if (weaponInHand.GetWeaponAmmoUseType() == WeaponAmmoType.Automate)
                    weaponUseAmmo.sprite = ammoSprites[1];
                else if (weaponInHand.GetWeaponAmmoUseType() == WeaponAmmoType.Shotgun)
                    weaponUseAmmo.sprite = ammoSprites[2];
            }
            else if (weaponInHand.GetWeaponRangeType() == Weapon.RangeWeaponType.Melee)
            {
                weaponUseAmmo.gameObject.SetActive(true);
                weaponUseAmmo.sprite = ammoSprites[3];
            }
            else weaponUseAmmo.gameObject.SetActive(false);

            ChangeAmmoInWeaponInfo();
            ChangeAmmoInInventoryInfo();
        }
        else CleareWeaponInfo();
    }

    private void ChangeAmmoInInventoryInfo()
    {
        if (weaponUseAmmo != null)
        {
            if (weaponInHand.GetWeaponRangeType() == Weapon.RangeWeaponType.Ranged)
            {
                if (weaponInHand.GetWeaponAmmoUseType() == WeaponAmmoType.Pistol)
                    ammoInInventoryText.text = ammoInventoryModel.GetCurrentPistolAmmo().ToString();
                else if (weaponInHand.GetWeaponAmmoUseType() == WeaponAmmoType.Automate)
                    ammoInInventoryText.text = ammoInventoryModel.GetCurrentAutomateAmmo().ToString();
                else if (weaponInHand.GetWeaponAmmoUseType() == WeaponAmmoType.Shotgun)
                    ammoInInventoryText.text = ammoInventoryModel.GetCurrentShotgunAmmo().ToString();
            }
            else if (weaponInHand.GetWeaponRangeType() == Weapon.RangeWeaponType.Melee)
                ammoInInventoryText.text = "";
            else ammoInInventoryText.text = "";
        }
        else CleareWeaponInfo();
    }

    private void ChangeAmmoInWeaponInfo()
    {
        if (weaponUseAmmo != null)
        {
            if (weaponInHand.GetWeaponRangeType() == Weapon.RangeWeaponType.Ranged)
            {
                weaponInHand.GetCurrentAmmoInWeapon().ToString();
            }
            else if (weaponInHand.GetWeaponRangeType() == Weapon.RangeWeaponType.Melee)
                ammoInWeaponText.text = "";
            else ammoInWeaponText.text = "";
        }
        else CleareWeaponInfo();
    }

    private void CleareWeaponInfo() 
    {
        ammoInInventoryText.text = "";
        weaponUseAmmo.gameObject.SetActive(false);
        ammoInWeaponText.text = "";
    }
}
