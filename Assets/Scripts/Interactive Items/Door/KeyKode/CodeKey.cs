using Interactiv;
using UnityEngine;

public class CodeKey : MonoBehaviour
{    
    [SerializeField] private Door doorNeedOpen;
    [SerializeField] private CodeKeyView view;
    [SerializeField] private string currentPinCode;
    private string pinCode;

    public void SetPincCode(string pinCode) => this.pinCode = pinCode;

    public void InputNumberButton(int number)
    {
        currentPinCode += number.ToString();
        view.ChangeInputText(string.Format("<color=black> {0} </color>", currentPinCode));
    }

    public void CheckPinCode()
    {
        if (currentPinCode == pinCode)
        {
            doorNeedOpen.OpenDoorForKey();
            view.ChangeInputText(string.Format("<color=green> {0} </color>", currentPinCode));
        }
        else
            view.ChangeInputText(string.Format("<color=red> {0} </color>", currentPinCode));
    }

    public void CleareInputField()
    {
        currentPinCode = "";
        view.ChangeInputText(string.Format("<color=black> {0} </color>", currentPinCode));
    }
}
