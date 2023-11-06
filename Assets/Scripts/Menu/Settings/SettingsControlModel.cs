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

    [SerializeField] private string interactivButton;

    [SerializeField] private string useMedicKitButton;
    [SerializeField] private string changeMedicKitButton;

    public float GetSensivity() => sensivity;
    public string GetMoveForwardButton() => moveForwardButton;
    public string GetMoveBackwardButton() => moveBackwardButton;
    public string GetMoveLeftButton() => moveLeftButton;
    public string GetMoveRightButton() => moveRightButton;
    public string GetSprintButton() => sprintButton;
    public string GetSquatDownButton() => squatDownButton;
    public string GetDashButton() => dashButton;

    public string GetInteractivButton() => interactivButton;

    public string GetUseMedicKitButton() => useMedicKitButton;
    public string GetChangeMedicKitButton() => changeMedicKitButton;
}
