using System.Collections;
using UnityEngine;

public class DashController : MonoBehaviour
{
    [SerializeField] private SettingsControlModel settings;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private MovementController movementController;
    [SerializeField] private float distanse;
    [SerializeField] private int dashStamina;
    [SerializeField] private int maxDashStamina;
    [SerializeField] private float timeRecoveryStamina;

    public int GetDashStamina()
    {
        return dashStamina;
    }
    private void Start()
    {
        StartCoroutine(RecoveryDashStamina());
    }

    private IEnumerator RecoveryDashStamina()
    {
        while(true) 
        {
            dashStamina += 1;
            CheckStaminaValue();
            yield return new WaitForSeconds(timeRecoveryStamina);
        }        
    } 

    private void CheckStaminaValue()
    {
        if(dashStamina <= 0) dashStamina = 0;
        if(dashStamina > maxDashStamina) dashStamina = maxDashStamina;
    }

    private void DashPlayer()
    {
        if (Input.GetKeyDown(settings.GetDashButton()) && dashStamina > 0)
        {
            Debug.Log("Dash");
            playerController.Move(movementController.GetMoveDirection() * distanse);
            dashStamina--;
        }
    }

    private void Update()
    {
        DashPlayer();
        
    }
}
