using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactiv
{
    public class KeyForDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private Door neededOpenDoor;
        public string GetDescription()
        {
            return "����� E, ����� ���� ����";
        }

        public void Interact()
        {
            neededOpenDoor.OpenDoorForKey();
            Destroy(gameObject);
        }
    }
}
