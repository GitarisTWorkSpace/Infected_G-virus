using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    private bool isOn = false;

    private void OnEnable()
    {
        InputManager.flashlightButtonCliked += SwichOnFlashLight;   
    }

    private void OnDisable()
    {
        InputManager.flashlightButtonCliked -= SwichOnFlashLight;
    }

    private void SwichOnFlashLight()
    {
        if (isOn)
        {
            flashlight.SetActive(false);
            isOn = false;
        }
        else if (!isOn)
        {
            flashlight.SetActive(true);
            isOn = true;
        }
    }
}
