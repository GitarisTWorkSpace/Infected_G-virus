using Interactiv;
using UnityEngine;

public class CodeKeyItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string pinCode;
    [SerializeField] private CodeKeyView view;
    [SerializeField] private CodeKey codeKey;

    public string GetDescription()
    {
        return "����� �, ����� ������ ���";
    }

    public void Interact()
    {
        codeKey.SetPincCode(pinCode);
        view.ActiveCodeKeyPanel();
    }
}
