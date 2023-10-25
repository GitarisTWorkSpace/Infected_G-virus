using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class DashStaminaView : MonoBehaviour
    {
        [SerializeField] private MovementConfig config;
        [SerializeField] private DashStamina stamina;

        [SerializeField] private Slider dashStaminaSlider;

        private void OnEnable()
        {
            DashStamina.changedDashStaminaValue += ChangeSliderValue;
        }

        private void OnDisable()
        {
            DashStamina.changedDashStaminaValue -= ChangeSliderValue;
        }

        private void Start()
        {
            dashStaminaSlider.maxValue = config.GetMaxDashStamineValue();
        }

        private void ChangeSliderValue()
        {
            dashStaminaSlider.value = stamina.GetDashStaminaValue();
        }        
    }
}