using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Inventory.Health
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private HealthModel model;

        [SerializeField] private Slider playerHealthPintsSlider;

        [SerializeField] private Image medicKitImage;
        [SerializeField] private Sprite[] medicKitSprites;
        [SerializeField] private TMP_Text countMedicKitByType;

        private void Start()
        {
            playerHealthPintsSlider.maxValue = model.GetMaxPlayerHealthPoint();
            ChangeSliderValue();
            ChangeSpriteImage(0);
            ChangeCountText(0);
        }

        private void OnEnable()
        {
            HealthController.playerHealthPointsChanged += ChangeSliderValue;
            HealthController.activMedicKitChanged += ChangeSpriteImage;
            HealthController.medicKitUsed += ChangeCountText;
            HealthModel.addedMedicKit += ChangeCountText;
        }

        private void OnDisable()
        {
            HealthController.playerHealthPointsChanged += ChangeSliderValue;
            HealthController.activMedicKitChanged += ChangeSpriteImage;
            HealthController.medicKitUsed += ChangeCountText;
            HealthModel.addedMedicKit += ChangeCountText;
        }

        private void ChangeSliderValue()
        {
            playerHealthPintsSlider.value = model.GetPlayerHealthPoint();
        }

        private void ChangeSpriteImage(int index)
        {
            medicKitImage.sprite = medicKitSprites[index];
            ChangeCountText(index);
        } 

        private void ChangeCountText(int index)
        {
            countMedicKitByType.text = model.GetCountMedicKit(index).ToString();
        }
    }
}