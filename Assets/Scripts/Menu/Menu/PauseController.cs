using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject HUD;
    private bool isActive = false;

    public void UnPaused()
    {
        isActive = false;
    }

    private void ChangeCursorState()
    {
        if (!isActive)
            Cursor.lockState = CursorLockMode.Locked;
        else if (isActive)
            Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pausePanel.SetActive(!isActive);
            HUD.SetActive(isActive);
            isActive = !isActive;
        }
        Time.timeScale = isActive ? 0 : 1;
        ChangeCursorState();
    }
}
