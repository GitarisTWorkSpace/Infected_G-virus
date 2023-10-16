using UnityEngine;

public class SettingsControlModel : MonoBehaviour
{
    [SerializeField] private float sensivity;

    public float GetSensivity()
    {
        return sensivity;
    }
}
