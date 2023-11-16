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

    WeaponModel weaponInHand;

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
            if (weaponInHand.GetWeaponRangeType() == WeaponModel.WeaponRangeType.Ranged)
            {
                weaponUseAmmo.gameObject.SetActive(true);
                if (weaponInHand.GetWeaponAmmoType() == WeaponAmmoType.Pistol)
                    weaponUseAmmo.sprite = ammoSprites[0];
                else if (weaponInHand.GetWeaponAmmoType() == WeaponAmmoType.Automate)
                    weaponUseAmmo.sprite = ammoSprites[1];
                else if (weaponInHand.GetWeaponAmmoType() == WeaponAmmoType.Shotgun)
                    weaponUseAmmo.sprite = ammoSprites[2];
            }
            else if (weaponInHand.GetWeaponRangeType() == WeaponModel.WeaponRangeType.Melee)
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
        if (weaponInHand != null)
        {
            if (weaponInHand.GetWeaponRangeType() == WeaponModel.WeaponRangeType.Ranged)
            {
                if (weaponInHand.GetWeaponAmmoType() == WeaponAmmoType.Pistol)
                    ammoInInventoryText.text = ammoInventoryModel.GetCurrentPistolAmmo().ToString();
                else if (weaponInHand.GetWeaponAmmoType() == WeaponAmmoType.Automate)
                    ammoInInventoryText.text = ammoInventoryModel.GetCurrentAutomateAmmo().ToString();
                else if (weaponInHand.GetWeaponAmmoType() == WeaponAmmoType.Shotgun)
                    ammoInInventoryText.text = ammoInventoryModel.GetCurrentShotgunAmmo().ToString();
            }
            else if (weaponInHand.GetWeaponRangeType() == WeaponModel.WeaponRangeType.Melee)
                ammoInInventoryText.text = "";
            else ammoInInventoryText.text = "";
        }
        else CleareWeaponInfo();
    }

    private void ChangeAmmoInWeaponInfo()
    {
        if (weaponInHand != null)
        {
            if (weaponInHand.GetWeaponRangeType() == WeaponModel.WeaponRangeType.Ranged)
                ammoInWeaponText.text = weaponInHand.GetAmmoInWeapon().ToString();
            else if (weaponInHand.GetWeaponRangeType() == WeaponModel.WeaponRangeType.Melee)
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
