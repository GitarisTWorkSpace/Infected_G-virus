using UnityEngine;

namespace Player
{

    [CreateAssetMenu(fileName = "MovementConfig", menuName = "Settings/MovementConfig")]
    public class MovementConfig : ScriptableObject
    {
        [Header("Mouse")]
        [SerializeField] private float sensivity;
        [SerializeField] private float smoothTime;

        [Header("Speeds")]
        [SerializeField] private float speedMove;
        [SerializeField] private float speedRun;
        [SerializeField] private float speedSquatDown;

        [Header("Sprint")]
        [SerializeField] private float maxSprintStaminaValue;
        [SerializeField] private float sprintStaminaDecrease;
        [SerializeField] private float sprintStaminaIncrease;

        [Header("Squat Down")]
        [SerializeField] private float defaultHeight;
        [SerializeField] private float squatDownHeight;

        [Header("Dash")]
        [SerializeField] private float dashdistanse;
        [SerializeField] private int maxDashStaminaValue;
        [SerializeField] private float timeRecoveryDashStamina;

        public float GetSensivity() => sensivity;
        public float GetSmoothTime() => smoothTime;
        public float GetSpeedMove() => speedMove;
        public float GetSpeedRun() => speedRun;
        public float GetSpeedSquatDown() => speedSquatDown;
        public float GetMaxSprintStaminaValue() => maxSprintStaminaValue;
        public float GetSprintStaminaDecrease() => sprintStaminaDecrease;
        public float GetSprintStaminaIncrease() => sprintStaminaIncrease;
        public float GetDefaultHeight() => defaultHeight;
        public float GetSquatDownHeight() => squatDownHeight;
        public float GetDashDistanse() => dashdistanse;
        public int GetMaxDashStamineValue() => maxDashStaminaValue;
        public float GetTimeRecoveryDashStamina() => timeRecoveryDashStamina;
    }
}
