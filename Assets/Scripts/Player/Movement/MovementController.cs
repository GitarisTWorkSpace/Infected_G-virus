using System;
using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        public static Action playerStoped;
        public static Action playerDashed;

        [SerializeField] private MovementConfig config;
        [SerializeField] private SprintStamina sprintStamina;
        [SerializeField] private DashStamina dashStamina;
        [SerializeField] private CharacterController playerController;

        private Vector3 moveDirection;
        private float xMove;
        private float zMove;

        [SerializeField] private bool isRun;
        [SerializeField] private bool isSquatDown;

        [SerializeField] private float speedCurrent;

        private void OnEnable()
        {
            InputManager.moveForwardButtonClicked += MoveForward;
            InputManager.moveBackwardButtonClicked += MoveBackward;
            InputManager.stopMoveVertical += StopMoveVertical;

            InputManager.moveRightButtonClicked += MoveRight;
            InputManager.moveLeftButtonClicked += MoveLeft;
            InputManager.stopMoveHorizontal += StopMoveHorizontal;

            InputManager.sprintButtonClicked += SprintMove;
            InputManager.sprintButtonNotClicked += StopSprintMove;

            InputManager.squatDownButtonClicked += SquatDownMove;
            InputManager.squatDownButtonClicked += PlayerSquatDown;
            InputManager.squatDownButtonNotClicked += StopSquatDownMove;
            InputManager.squatDownButtonNotClicked += PlayerUp;

            InputManager.dashButtonClicked += DashPlayer;
        }

        private void OnDisable()
        {
            InputManager.moveForwardButtonClicked -= MoveForward;
            InputManager.moveBackwardButtonClicked -= MoveBackward;
            InputManager.stopMoveVertical -= StopMoveVertical;

            InputManager.moveRightButtonClicked -= MoveRight;
            InputManager.moveLeftButtonClicked -= MoveLeft;
            InputManager.stopMoveHorizontal -= StopMoveHorizontal;

            InputManager.sprintButtonClicked -= SprintMove;
            InputManager.sprintButtonNotClicked -= StopSprintMove;

            InputManager.squatDownButtonClicked -= SquatDownMove;
            InputManager.squatDownButtonClicked -= PlayerSquatDown;
            InputManager.squatDownButtonNotClicked -= StopSquatDownMove;
            InputManager.squatDownButtonNotClicked -= PlayerUp;

            InputManager.dashButtonClicked -= DashPlayer;
        }

        #region ButtonsMethod
        private void MoveForward() => zMove = 1;
        private void MoveBackward() => zMove = -1;
        private void StopMoveVertical() => zMove = 0;

        private void MoveRight() => xMove = 1;
        private void MoveLeft() => xMove = -1;
        private void StopMoveHorizontal() => xMove = 0;

        private void SprintMove() => isRun = true;
        private void StopSprintMove() => isRun = false;

        private void SquatDownMove() => isSquatDown = true;
        private void PlayerSquatDown() => playerController.height = config.GetSquatDownHeight();
        private void StopSquatDownMove() => isSquatDown = false;
        private void PlayerUp() => playerController.height = config.GetDefaultHeight();
        #endregion 

        private bool IsMoved() => xMove != 0 || zMove != 0;
        private bool IsRun() => isRun && sprintStamina.CanSprint();

        private void PlayerStoped()
        {
            if (speedCurrent == 0) playerStoped?.Invoke();
        }

        private void SetSpeed()
        {
            if (IsMoved())
                speedCurrent = config.GetSpeedMove();
            else 
                speedCurrent = 0;
            if (IsMoved() && IsRun())
                speedCurrent = config.GetSpeedRun();
            if (IsMoved() && isSquatDown)
                speedCurrent = config.GetSpeedSquatDown();
            if (IsMoved() && IsRun() && isSquatDown)
                speedCurrent = config.GetSpeedRun() - config.GetSpeedSquatDown();
        }       

        private void MovePlayer()
        {
            SetSpeed();
            PlayerStoped();

            if (playerController.isGrounded)
            {
                moveDirection = new Vector3(xMove, 0, zMove);
                moveDirection = transform.TransformDirection(moveDirection);
            }

            moveDirection.y -= 0.1f;

            playerController.Move(moveDirection * speedCurrent * Time.deltaTime);
        }

        private void DashPlayer()
        {
            if (dashStamina.CanDash())
            {
                playerController.Move(moveDirection * config.GetDashDistanse());
                playerDashed?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }
    }
}