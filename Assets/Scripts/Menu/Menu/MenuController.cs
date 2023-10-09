using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] public TMP_Text versionGameText;

    [SerializeField] private string[] _nameScene = new string[5];
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (versionGameText == null) Debug.LogWarning("������ ����� ����������� " + name);
        else
            versionGameText.text = Application.version.ToString();
        if (_nameScene == null)
            Debug.LogWarning("����� �������� ���� " + name);
    }

    public void MoveToScene(string nameScene)
    {
        if(nameScene == null)
        {
            Debug.LogWarning("������� �������� ����� " + name);
            return;
        }

        foreach(string scene in _nameScene) 
        {
            if (scene == nameScene)
            {
                SceneManager.LoadScene(nameScene);
                return;
            }
        }
        
        Debug.LogWarning("����� �� ������� " + name);
    } 

    public void ExtiOfGame()
    {
        Application.Quit();
    }
}
