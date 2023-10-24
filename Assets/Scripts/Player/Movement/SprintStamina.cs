using UnityEngine;

namespace Player
{
    public class SprintStamina : MonoBehaviour
    {
        [SerializeField] private MovementConfig config;
        [SerializeField] private float sprinatStanimaValue;
        public float GetSprintStaminaValue() => sprinatStanimaValue;
        public bool CanSprint() => sprinatStanimaValue > 0 ? true : false;        

        private void Start()
        {
            sprinatStanimaValue = config.GetMaxSprintStaminaValue();
        }

        private void OnEnable()
        {
            InputManager.sprintButtonClicked += StaminaDecrease;
            MovementController.playerStoped += StaminaIncrease;
        }

        private void OnDisable()
        {
            InputManager.sprintButtonClicked -= StaminaDecrease;
            MovementController.playerStoped -= StaminaIncrease;
        }

        private void StaminaCheck()
        {
            if (sprinatStanimaValue <= 0) sprinatStanimaValue = 0;
            if (sprinatStanimaValue > config.GetMaxSprintStaminaValue()) sprinatStanimaValue = config.GetMaxSprintStaminaValue();
        }

        private void StaminaDecrease()
        {
            sprinatStanimaValue -= config.GetSprintStaminaDecrease();
            StaminaCheck();
        }

        private void StaminaIncrease()
        {
            sprinatStanimaValue += config.GetSprintStaminaIncrease();
            StaminaCheck();
        }
    }
}