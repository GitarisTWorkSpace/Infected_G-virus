using TMPro;
using UnityEngine;

public class CodeKeyView : MonoBehaviour
{
    [SerializeField] private PauseController pauseController;
    [SerializeField] private GameObject CodeKeyPanel;

    [SerializeField] private TMP_Text InpuText;

    public void ActiveCodeKeyPanel()
    {
        CodeKeyPanel.SetActive(true);

        pauseController.canPause = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void DeactivateCodeKeyPanel()
    {
        CodeKeyPanel.SetActive(false);

        pauseController.canPause= true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void ChangeInputText(string inputText)
    {
        InpuText.text = inputText;
    }
}
