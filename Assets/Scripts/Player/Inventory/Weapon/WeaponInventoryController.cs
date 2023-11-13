using System;
using UnityEngine;

public class WeaponInventoryController : MonoBehaviour
{
    public static Action<int> swichedWeaponInHands;

    [SerializeField] private WeaponInventoryModel model;
    [SerializeField] private Weapon inHand;
    [SerializeField] private GameObject weaponInHand;

    private void SwichWeaponInHands()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            inHand = model.GetWeaponByIndex(0);
            weaponInHand = Instantiate(inHand.gameObject, inHand.GetPositionInHand(), Quaternion.identity, transform);
            swichedWeaponInHands?.Invoke(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            inHand = model.GetWeaponByIndex(1);
            weaponInHand = Instantiate(inHand.gameObject, inHand.GetPositionInHand(), Quaternion.identity, transform);
            swichedWeaponInHands?.Invoke(1);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            inHand = model.GetWeaponByIndex(2);
            weaponInHand = Instantiate(inHand.gameObject, inHand.GetPositionInHand(), Quaternion.identity, transform);
            swichedWeaponInHands?.Invoke(2);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            inHand = model.GetWeaponByIndex(3);
            weaponInHand = Instantiate(inHand.gameObject, inHand.GetPositionInHand(), Quaternion.identity, transform);
            swichedWeaponInHands?.Invoke(3);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            inHand = model.GetWeaponByIndex(4);
            weaponInHand = Instantiate(inHand.gameObject, inHand.GetPositionInHand(), Quaternion.identity, transform);
            swichedWeaponInHands?.Invoke(4);
        }
    }

    private void Update()
    {
        SwichWeaponInHands();
    }
}
