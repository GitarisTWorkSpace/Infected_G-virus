using Interactiv;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteractable
{
    [SerializeField] private AmmoKit ammoKit;
    [SerializeField] private MedicKit medicKit;

    public string GetDescription()
    {
        return "Нажми Е, чтобы открыть";
    }

    public void Interact()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 0) SpawnAmmo();
        else if (rnd == 1) SpawnMedicKit();
        Destroy(gameObject);
    }

    private void SpawnMedicKit()
    {
        MedicKit medic = medicKit;
        medic.SetMedicKitIndex(Random.Range(0,3));
        medic.SetMedicKitCount(Random.Range(1,2));
        Instantiate(medic.gameObject, transform.position, Quaternion.identity);
    }

    private void SpawnAmmo()
    {
        AmmoKit ammo = ammoKit;
        var ammoType = SetRandomAmmoType();
        ammo.SetTypeAmmo(ammoType);
        ammo.SetAmmoCount(SetAmmoCount(ammoType));
        Instantiate(ammo.gameObject, transform.position, Quaternion.identity);
    }

    private WeaponAmmoType SetRandomAmmoType()
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0: return WeaponAmmoType.Pistol;
            case 1: return WeaponAmmoType.Automate;
            case 2: return WeaponAmmoType.Shotgun;
            default:
                return WeaponAmmoType.Pistol;
        }
    }

    private int SetAmmoCount(WeaponAmmoType type)
    {
        if (type == WeaponAmmoType.Pistol)
            return Random.Range(0, 17 * 3);
        else if (type == WeaponAmmoType.Automate)
            return Random.Range(0, 30 * 3);
        else if (type == WeaponAmmoType.Shotgun)
            return Random.Range(0, 10 * 3);
        return 0;
    }
}
