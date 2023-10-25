using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class DashStamina : MonoBehaviour
    {
        public static Action changedDashStaminaValue;

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
            MovementController.playerDashed += StaminaDecrease;
        }

        private void OnDisable()
        {
            MovementController.playerDashed -= StaminaDecrease;
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
            changedDashStaminaValue?.Invoke();
        }

        private IEnumerator StaminaIncrease()
        {
            while (true)
            {
                dashStaminaValue += 1;
                StaminaCheck();
                changedDashStaminaValue?.Invoke();
                yield return new WaitForSeconds(config.GetTimeRecoveryDashStamina());
            }
        }
    }
}
