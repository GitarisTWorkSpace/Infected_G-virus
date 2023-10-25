using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Player 
{
    public class SprintStaminaView : MonoBehaviour
    {
        [SerializeField] private MovementConfig config;
        [SerializeField] private SprintStamina stamina;

        [SerializeField] private GameObject sprintSliderBar;
        [SerializeField] private Slider sprintStaminaSlider;

        [SerializeField] private float hideTime;
        private bool isActive;

        private void OnEnable()
        {
            InputManager.sprintButtonClicked += ChangeSliderValue;
            InputManager.sprintButtonNotClicked += ChangeSliderValue;
        }

        private void OnDisable()
        {
            InputManager.sprintButtonClicked -= ChangeSliderValue;
            InputManager.sprintButtonNotClicked -= ChangeSliderValue;
        }

        void Start()
        {
            sprintStaminaSlider.maxValue = config.GetMaxSprintStaminaValue();
        }

        private void ChangeSliderValue()
        {
            sprintStaminaSlider.value = stamina.GetSprintStaminaValue();
            if (sprintStaminaSlider.value != sprintStaminaSlider.maxValue)
            {
                isActive = true;
                StartCoroutine(ViewSlider());
            }    
            else if (sprintStaminaSlider.value == sprintStaminaSlider.maxValue)
            {
                isActive = false;
                StartCoroutine(ViewSlider());
            }
        }

        private IEnumerator ViewSlider()
        {
            yield return new WaitForSeconds(hideTime);
            sprintSliderBar.SetActive(isActive);
        }        
    }
}