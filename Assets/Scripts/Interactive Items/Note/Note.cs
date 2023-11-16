using Player;
using TMPro;
using UnityEngine;

namespace Interactiv
{
    public class Note : MonoBehaviour, IInteractable
    {
        [SerializeField] private PauseController pauseController;
        [SerializeField] private GameObject NotePanel;
        [SerializeField] private NoteModel model;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text noteText;

        private bool isActive;
        public string GetDescription()
        {
            return "Нажмите E, чтобы прочесть";
        }

        public void Interact()
        {
            isActive = true;
            NotePanel.SetActive(isActive);
            titleText.text = model.GetNoteTitle();
            noteText.text = model.GetNoteDescription();

            pauseController.canPause = false;
            Time.timeScale = isActive ? 0 : 1;
            ChangeCursorState();
        }

        private void ChangeCursorState()
        {
            if (!isActive)
                Cursor.lockState = CursorLockMode.Locked;
            else if (isActive)
                Cursor.lockState = CursorLockMode.None;
        }

        public void CloseNotePanel()
        {
            isActive = false;
            NotePanel.SetActive(isActive);

            pauseController.canPause = true;
            Time.timeScale = isActive ? 0 : 1;
            ChangeCursorState();
        }
    }
}
