using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject HUD;
    private bool isActive = false;
    public bool canPause = true;
    public void UnPaused()
    {
        isActive = false;
        ChangeCursorState();
        SetTimeScale();
    }

    private void ChangeCursorState()
    {
        if (!isActive)
            Cursor.lockState = CursorLockMode.Locked;
        else if (isActive)
            Cursor.lockState = CursorLockMode.None;
    }

    private void SetTimeScale()
    {
        Time.timeScale = isActive ? 0 : 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            pausePanel.SetActive(!isActive);
            HUD.SetActive(isActive);
            isActive = !isActive;
            ChangeCursorState();
            SetTimeScale();
        }   
    }
}
