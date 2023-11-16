using System;
using UnityEngine;

public class WeaponInventoryController : MonoBehaviour
{
    public static Action<int> swichedWeaponInHands;

    [SerializeField] private WeaponInventoryModel model;
    [SerializeField] private WeaponModel inHand;
    [SerializeField] private GameObject weaponInHand;

    private void SwichWeaponInHands()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(weaponInHand);
            weaponInHand = null;
            inHand = model.GetWeaponByIndex(0);
            weaponInHand = Instantiate(inHand.GetWeaponPrefab(), transform.position, transform.rotation, transform);
            swichedWeaponInHands?.Invoke(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(weaponInHand);
            weaponInHand = null;
            inHand = model.GetWeaponByIndex(1);
            weaponInHand = Instantiate(inHand.GetWeaponPrefab(), transform.position, transform.rotation, transform);
            swichedWeaponInHands?.Invoke(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(weaponInHand);
            weaponInHand = null;
            inHand = model.GetWeaponByIndex(2);
            weaponInHand = Instantiate(inHand.GetWeaponPrefab(), transform.position, transform.rotation, transform);
            swichedWeaponInHands?.Invoke(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Destroy(weaponInHand);
            weaponInHand = null;
            inHand = model.GetWeaponByIndex(3);
            weaponInHand = Instantiate(inHand.GetWeaponPrefab(), transform.position, transform.rotation, transform);
            swichedWeaponInHands?.Invoke(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Destroy(weaponInHand);
            weaponInHand = null;
            inHand = model.GetWeaponByIndex(4);
            weaponInHand = Instantiate(inHand.GetWeaponPrefab(), transform.position, transform.rotation, transform);
            swichedWeaponInHands?.Invoke(4);
        }
    }

    private void Update()
    {
        SwichWeaponInHands();
    }
}
