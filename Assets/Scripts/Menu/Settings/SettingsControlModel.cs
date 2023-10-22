using UnityEngine;

[CreateAssetMenu(fileName = "SettingsControl", menuName = "Settings/SettingsControl")]
public class SettingsControlModel : ScriptableObject
{
    [SerializeField] private float sensivity;
    [SerializeField] private string moveForwardButton;
    [SerializeField] private string moveBackwardButton;
    [SerializeField] private string moveLeftButton;
    [SerializeField] private string moveRightButton;
    [SerializeField] private string sprintButton;
    [SerializeField] private string squatDownButton;
    [SerializeField] private string dashButton;

    public float GetSensivity()
    {
        return sensivity;
    }

    public string GetMoveForwardButton()
    {
        return moveForwardButton;
    }

    public string GetMoveBackwardButton()
    {
        return moveBackwardButton;
    }

    public string GetMoveLeftButton()
    {
        return moveLeftButton;
    }

    public string GetMoveRightButton()
    {
        return moveRightButton;
    }

    public string GetSprintButton()
    {
        return sprintButton;
    }

    public string GetSquatDownButton()
    {
        return squatDownButton;
    }

    public string GetDashButton() 
    { 
        return dashButton;
    }
}
