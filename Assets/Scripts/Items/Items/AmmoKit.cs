using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoKit : MonoBehaviour
{
    [SerializeField] private AmmoInventoryModel ammoInventory;
    [SerializeField] private WeaponAmmoType typeAmmo;
    [SerializeField] private int countAmmo;

    public void SetTypeAmmo(WeaponAmmoType typeAmmo)
    {
        this.typeAmmo = typeAmmo;
    }

    public void SetAmmoCount(int cauntAmmo)
    {
        this.countAmmo = cauntAmmo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            if (typeAmmo == WeaponAmmoType.Pistol)
                ammoInventory.AddPistolAmmo(countAmmo);
            else if (typeAmmo == WeaponAmmoType.Automate)
                ammoInventory.AddAutomateAmmo(countAmmo);
            else if (typeAmmo == WeaponAmmoType.Shotgun)
                ammoInventory.AddShotgunAmmo(countAmmo);

            Destroy(gameObject);
        }
    }
}
