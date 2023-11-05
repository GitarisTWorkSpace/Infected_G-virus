using UnityEngine;

namespace Interactiv
{
    [CreateAssetMenu(fileName = "Note", menuName = "Settings/Note")]
    public class NoteModel : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private string description;

        public string GetNoteTitle() => title;
        public string GetNoteDescription() => description;
    }
}