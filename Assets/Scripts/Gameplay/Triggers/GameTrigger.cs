using TMPro;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    public enum TriggerType { Enter, Exit };
    [SerializeField] private TriggerType triggerType;
    [SerializeField] private TMP_Text taskText;
    [SerializeField] private string task;
    [SerializeField] private GameTrigger nextTringer;

    private void OnEnable()
    {
        taskText.text = task;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerType == TriggerType.Enter)
        {
            if (other.tag == "Player")
            {
                if (nextTringer != null) nextTringer.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerType == TriggerType.Exit)
        {
            if (other.tag == "Player")
            {
                if (nextTringer != null) nextTringer.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
