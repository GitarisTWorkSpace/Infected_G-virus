using Player;
using System;
using Unity.VisualScripting;
using UnityEngine;
using static WeaponModel;

public class Weapon : MonoBehaviour
{
    public static Action weaponShoted;

    [SerializeField] private WeaponModel model;
    [SerializeField] private bool inHand;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask layerMask;


    private Animator animator;

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

    private void Start()
    {
        if (model.GetAminator() != null)
        {
            animator = model.GetAminator();
        }
        playerCamera = Camera.main;
    }

    private void SmallDamageAttak()
    {
        if (model.GetWeaponRangeType() == WeaponRangeType.Melee && inHand)
        {
            if (model.GetAminator() != null)
            {
                animator.SetBool("SmallAtack", true);
            }
            PerformRaycast(model.GetSmallDamage());
        }
    }

    private void LargeDamageAttak() 
    {
        if (model.GetWeaponRangeType() == WeaponRangeType.Melee && inHand)
        {
            if (model.GetAminator() != null)
            {
                animator.SetBool("LargeAtack", true);
            }
            PerformRaycast(model.GetLargeDamage());
        }
    }

    private void Shot()
    {
        if (model.GetWeaponRangeType() == WeaponRangeType.Ranged && inHand)
        {
            float nextFire = 0;
            
            if (model.GetTypeWeaponFireRate() == TypeFireRate.Auto && Time.time > nextFire)
            {
                nextFire = Time.time + model.GetFireRate();
                if (model.GetAmmoInWeapon() > 0)
                {
                    PerformRaycast(model.GetRangeDamage());
                    model.RemoveAmmoInWeapon(1);
                    weaponShoted?.Invoke();
                }
            }
            else if (model.GetTypeWeaponFireRate() == TypeFireRate.Semi)
            {
                if (model.GetAmmoInWeapon() > 0)
                {
                    PerformRaycast(model.GetRangeDamage());
                    model.RemoveAmmoInWeapon(1);
                    weaponShoted?.Invoke();
                }
            }
        }
    }

    private void TakeAim()
    {

    }

    private void Reload()
    {
        if (model.GetWeaponRangeType() == WeaponRangeType.Ranged && inHand)
        {
            if (model.GetAmmoInWeapon() == model.GetMaxAmmoInWeapon()) return;
            else
                model.ReloadAmmoInWeapon(model.GetMaxAmmoInWeapon() - model.GetAmmoInWeapon());
        }
        weaponShoted?.Invoke();
    }

    private void PerformRaycast(float damage)
    {
        var direction = model.GetUseSpread() ? playerCamera.transform.forward + CalculationSpread() : playerCamera.transform.forward;
        var ray = new Ray(playerCamera.transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, model.GetRange(), layerMask))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable damageble))
            {
                damageble.TakeDamage(damage);
            }
        }
    }

    private Vector3 CalculationSpread()
    {
        return new Vector3
        {
            x = UnityEngine.Random.Range(-model.GetSpreadFactor(), model.GetSpreadFactor()),
            y = UnityEngine.Random.Range(-model.GetSpreadFactor(), model.GetSpreadFactor()),
            z = UnityEngine.Random.Range(-model.GetSpreadFactor(), model.GetSpreadFactor())
        };
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, model.GetRange(), layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * model.GetRange();

            DrawRay(ray, hitPosition, model.GetRange(), Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }

#endif
}
