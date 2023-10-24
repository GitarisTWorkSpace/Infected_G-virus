using System.Collections;
using UnityEngine;

namespace Player
{
    public class DashStamina : MonoBehaviour
    {
        [SerializeField] private MovementConfig config;
        [SerializeField] private int dashStaminaValue;

        public int GetDashStaminaValue() => dashStaminaValue;

        public bool CanDash() => dashStaminaValue > 0 ? true : false;

        private void Start()
        {
            dashStaminaValue = config.GetMaxDashStamineValue();
            StartCoroutine(StaminaIncrease());
        }

        private void OnEnable()
        {
            InputManager.dashButtonClicked += StaminaDecrease;
        }

        private void OnDisable()
        {
            InputManager.dashButtonClicked -= StaminaDecrease;
        }

        private void StaminaCheck()
        {
            if (dashStaminaValue <= 0) dashStaminaValue = 0;
            if (dashStaminaValue > config.GetMaxDashStamineValue()) dashStaminaValue = config.GetMaxDashStamineValue();
        }

        private void StaminaDecrease()
        {
            dashStaminaValue -= 1;
            StaminaCheck();
        }

        private IEnumerator StaminaIncrease()
        {
            while (true)
            {
                dashStaminaValue += 1;
                StaminaCheck();
                yield return new WaitForSeconds(config.GetTimeRecoveryDashStamina());
            }
        }
    }
}
