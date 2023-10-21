using UnityEngine;

public class SquatDownCotroller : MonoBehaviour
{
    [SerializeField] private SpeedModel speedModel;
    [SerializeField] private SettingsControlModel settings;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float defaulHeight;
    [SerializeField] private float squatDownHeight;

    private void SquatDownPlayer()
    {
        if (Input.GetKey(settings.GetSquatDownButton()))
        {
            playerController.height = squatDownHeight;
            speedModel.isSquatDown = true;
        }
        else
        {
            playerController.height = defaulHeight;
            speedModel.isSquatDown = false;
        }
    }

    private void FixedUpdate()
    {
        SquatDownPlayer();
    }
}
