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

        public static Action<bool> interactiveButtonCliked;

        public static Action flashlightButtonCliked;

        public static Action semiFireButtonCliked;
        public static Action autoFireButtonCliked;
        public static Action aimButtonCliked;
        public static Action weaponRealodButtonCliked;

        public static Action smallWeaponAttakButtonCliked;
        public static Action largeweaponAttakButtonCliked;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

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
        }

        private void DashPlayer()
        {
            if (Input.GetKeyDown(settings.GetDashButton()))
                dashButtonClicked?.Invoke();
        }

        private void Interactiv() 
        {
            if (Input.GetKeyDown(settings.GetInteractivButton()))
                interactiveButtonCliked?.Invoke(true);
            else
                interactiveButtonCliked?.Invoke(false);
        }

        private void UseFlashlight()
        {
            if(Input.GetKeyDown(settings.GetUseFlathlightButton()))
                flashlightButtonCliked?.Invoke();
        }

        private void UseWapon()
        {
            if (Input.GetKeyDown(settings.GetFireButton()))
                semiFireButtonCliked?.Invoke();
            if (Input.GetKey(settings.GetFireButton()))
                autoFireButtonCliked?.Invoke();
            if (Input.GetKeyDown(settings.GetAimButton()))
                aimButtonCliked?.Invoke();
            if (Input.GetKeyDown(settings.GetWeaponReloadButton()))
                weaponRealodButtonCliked?.Invoke();

            if (Input.GetKeyDown(settings.GetSmallWeaponAttakButton()))
                smallWeaponAttakButtonCliked?.Invoke();
            if (Input.GetKeyDown(settings.GetLargeWeaponAttakButton()))
                largeweaponAttakButtonCliked?.Invoke();
        }

        private void Update()
        {
            DashPlayer();
            Interactiv();
            UseFlashlight();
            UseWapon();
        }

        private void FixedUpdate()
        {            
            CheckMovementInput();
        }
    }
}