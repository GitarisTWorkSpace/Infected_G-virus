using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private SettingsControlModel settingsControl;

    [SerializeField] private float speedMove;
    [SerializeField] private float speed; // убрать сериализацию
    [SerializeField] private float speedCurrent; // убрать сериализацию

    private Vector3 moveDirection;
    private float xMove;
    private float zMove;

    public float GetSpeedCurrent()
    {
        return speedCurrent;
    }

    public void SetSpeed(float speedValue)
    {
        speed += speedValue;
    }

    private void MoveSpeed()
    {
        speed = speedMove;
    }

    private void StopMoveSpeed()
    {
        speed = 0f;
    }

    private void Stop()
    {
        speedCurrent = 0f;
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
            MoveSpeed();
        }
        else if(xMove == 0 && zMove == 0)
        {
            StopMoveSpeed();
            Stop();
        }

        //xMove = Input.GetAxis("Horizontal");
        //zMove = Input.GetAxis("Vertical");

        speedCurrent = speed;

        if (playerController.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0, zMove);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= 0.1f;

        playerController.Move(moveDirection * speedCurrent * Time.deltaTime);
    }

    private void Update()
    {
        MovePlayer();
    }
}


