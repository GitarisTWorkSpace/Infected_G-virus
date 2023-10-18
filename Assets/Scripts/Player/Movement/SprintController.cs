using UnityEngine;

public class SprintController : MonoBehaviour
{
    [SerializeField] private SpeedModel speedModel;
    [SerializeField] private MovementController movement;
    [SerializeField] private SettingsControlModel settings;

    [SerializeField] private float speedRun;
    [SerializeField] private float smoothSpeed;

    [SerializeField] private float maxStaminaValue;
    [SerializeField] private float staminaDecrease;
    [SerializeField] private float staminaIncrease;
    [SerializeField] private float staminaValue; // убрать сериализацию

    public float GetStaminaValue()
    {
        return staminaValue;
    }

    private void StaminaCheck()
    {
        if(staminaValue <= 0) staminaValue = 0;
        if(staminaValue > maxStaminaValue) staminaValue = maxStaminaValue;
    }

    private void StaminaDecrease()
    {
        staminaValue -= staminaDecrease;
    }

    private void StaminaIncrease()
    {
        staminaValue += staminaIncrease;
    }

    private void PlayerSprint()
    {
        if (Input.GetKey(settings.GetSprintButton()))
        {
            speedModel.SetSpeed(speedRun);
            StaminaDecrease();
            StaminaCheck();
        }
        else if(movement.GetSpeedCurrent() == 0)
        {
            StaminaIncrease();
            StaminaCheck();
        }
    }

    private void FixedUpdate()
    {
        PlayerSprint();
    }
}
