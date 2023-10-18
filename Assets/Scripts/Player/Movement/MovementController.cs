using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private SettingsControlModel settingsControl;
    [SerializeField] private SpeedModel speedModel;

    [SerializeField] private float speedMove;
    [SerializeField] private float speedCurrent; // ������ ������������

    private Vector3 moveDirection;
    private float xMove;
    private float zMove;

    public float GetSpeedCurrent()
    {
        return speedCurrent;
    }

    private void HorizontalMove()
    {
        if (Input.GetKey(settingsControl.GetMoveForwardButton()))
        {
            zMove = 1; 
        }
        else if (Input.GetKey(settingsControl.GetMoveBackwardButton()))
        {
            zMove = -1;
        }
        else
        {
            zMove = 0;
        }
    }

    private void VerticalMove()
    {
        if (Input.GetKey(settingsControl.GetMoveRightButton()))
        {
            xMove = 1;
        }
        else if (Input.GetKey(settingsControl.GetMoveLeftButton()))
        {
            xMove = -1;
        }
        else
        {
            xMove = 0;
        }
    }

    private void MovePlayer()
    {
        HorizontalMove();
        VerticalMove();

        if(xMove != 0 || zMove != 0)
        {
            speedModel.SetSpeed(speedMove);
        }
        else if(xMove == 0 && zMove == 0)
        {
            //speedModel.Stop();
        }

        //xMove = Input.GetAxis("Horizontal");
        //zMove = Input.GetAxis("Vertical");

        speedCurrent = speedModel.GetSpeed();

        if (playerController.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0, zMove);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= 0.1f;

        playerController.Move(moveDirection * speedCurrent * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}

