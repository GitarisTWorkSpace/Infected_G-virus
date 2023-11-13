using Interactiv;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour, IInteractable
{
    [SerializeField] private WeaponInventoryModel inventoryModel;
    public string GetDescription()
    {
        return "Нажми Е, чтобы подобрать оружие";
    }

    public void Interact()
    {
        for (int i = 0; i < inventoryModel.GetAllWeaponInInventory().Length; i++)
        {
            if (inventoryModel.GetWeaponByIndex(i) == null)
            {
                inventoryModel.AddWeaponInInventory(i, gameObject.GetComponent<Weapon>());
                return;
            }
        }
    }
}
