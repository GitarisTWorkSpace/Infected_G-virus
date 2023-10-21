using UnityEngine;

public class SprintController : MonoBehaviour
{
    [SerializeField] private SpeedModel speedModel;
    [SerializeField] private SettingsControlModel settings;

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
        StaminaCheck();
    }

    private void StaminaIncrease()
    {
        staminaValue += staminaIncrease;
        StaminaCheck();
    }

    private void PlayerSprint()
    {
        if (Input.GetKey(settings.GetSprintButton()) && staminaValue > 0)
        {
            speedModel.isRun = true;
            if (speedModel.GetSpeedCurrent() > 0)
                StaminaDecrease();
        }
        else
            speedModel.isRun= false;

        if (speedModel.GetSpeedCurrent() == 0)
            StaminaIncrease();
    }

    private void FixedUpdate()
    {
        PlayerSprint();
    }
}
