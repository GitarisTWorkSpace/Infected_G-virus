using System;
using UnityEngine;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private SettingsControlModel settings;

        public static Action moveForwardButtonClicked;
        public static Action moveBackwardButtonClicked;
        public static Action stopMoveVertical;
        public static Action moveLeftButtonClicked;
        public static Action moveRightButtonClicked;
        public static Action stopMoveHorizontal;
        public static Action sprintButtonClicked;
        public static Action sprintButtonNotClicked;
        public static Action squatDownButtonClicked;
        public static Action squatDownButtonNotClicked;
        public static Action dashButtonClicked;

        private void HorizontalMove()
        {
            if (Input.GetKey(settings.GetMoveRightButton()))
                moveRightButtonClicked?.Invoke();
            else if (Input.GetKey(settings.GetMoveLeftButton()))
                moveLeftButtonClicked?.Invoke();
            else 
                stopMoveHorizontal?.Invoke();
        }

        private void VerticalMove()
        {
            if (Input.GetKey(settings.GetMoveForwardButton()))
                moveForwardButtonClicked?.Invoke();
            else if (Input.GetKey(settings.GetMoveBackwardButton()))
                moveBackwardButtonClicked?.Invoke();
            else
                stopMoveVertical?.Invoke();
        }

        private void SprintMove()
        {
            if (Input.GetKey(settings.GetSprintButton()))
                sprintButtonClicked?.Invoke();
            else
                sprintButtonNotClicked?.Invoke();
        }

        private  void SquatDowmMove()
        {
            if (Input.GetKey(settings.GetSquatDownButton()))
                squatDownButtonClicked?.Invoke();
            else
                squatDownButtonNotClicked?.Invoke();
        }

        private void CheckMovementInput()
        {
            HorizontalMove();
            VerticalMove();

            SprintMove();

            SquatDowmMove();

            if (Input.GetKeyDown(settings.GetDashButton()))
                dashButtonClicked?.Invoke();
        }

        private void Update()
        {
            CheckMovementInput();
        }
    }
}