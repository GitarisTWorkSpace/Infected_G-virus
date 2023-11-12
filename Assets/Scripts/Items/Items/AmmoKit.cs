using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoKit : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
