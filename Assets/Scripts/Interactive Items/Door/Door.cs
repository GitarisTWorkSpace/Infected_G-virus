using Interactiv;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactiv
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private enum openTypeENUM { rot_to_open, move_to_open }
        [SerializeField] private openTypeENUM openType;

        [SerializeField] private enum doorAxisENUM {X, Y, Z};
        [SerializeField] doorAxisENUM doorAxis;

        [SerializeField] private bool onlyOpen;
        [SerializeField] private bool canBeOpenedNow;
         private bool isOpen;

        [SerializeField] private float openSpeed;
        [SerializeField] private float openDistanceOrAngle;

        [SerializeField] private AudioSource moveOrRotataionSound;
        [SerializeField] private AudioSource openSound;
        [SerializeField] private AudioSource closeSound;
        [SerializeField] private AudioSource notOpeningSound;

        [SerializeField] private GameObject doorHandle;

        [SerializeField] private enum hanleAxisENUM {X, Y, Z};
        [SerializeField] private hanleAxisENUM hanleAxis;

        [SerializeField] private float handleRotationAngle;
        private Quaternion startRoptation;
        private float startDistanceOrAngle;
        private bool openCloseON;

        private void Start()
        {
            if (openType == openTypeENUM.move_to_open)
            {
                if (doorAxis == doorAxisENUM.X)
                    startDistanceOrAngle = transform.localPosition.x;
                else if (doorAxis == doorAxisENUM.Y)
                    startDistanceOrAngle = transform.localPosition.y;
                else if (doorAxis == doorAxisENUM.Z)
                    startDistanceOrAngle = transform.localPosition.z;
            }
            else
            {
                if (doorAxis == doorAxisENUM.X)
                    startDistanceOrAngle = transform.localEulerAngles.x;
                else if (doorAxis == doorAxisENUM.Y)
                    startDistanceOrAngle = transform.localEulerAngles.y;
                else if (doorAxis == doorAxisENUM.Z)
                    startDistanceOrAngle = transform.localEulerAngles.z;
            }
            if (doorHandle) startRoptation = doorHandle.transform.localRotation;
        }
        public string GetDescription()
        {
            if (canBeOpenedNow)
                return "Нажми F, чтобы открыть дверь";
            else if (onlyOpen && isOpen)
                return "Нельзя закрыть";
            else
                return "Закрыто";
        }

        public void Interact()
        {
            if (doorHandle) 
            {
                if (hanleAxis == hanleAxisENUM.X) 
                    doorHandle.transform.localRotation = Quaternion.Euler(handleRotationAngle, 0f, 0f);
                else if (hanleAxis == hanleAxisENUM.Y)
                    doorHandle.transform.localRotation = Quaternion.Euler(0f, handleRotationAngle, 0f);
                else if (hanleAxis == hanleAxisENUM.Z)
                    doorHandle.transform.localRotation = Quaternion.Euler(0f, 0f, handleRotationAngle);
            }
            OpenDoor();
            if (doorHandle)
                doorHandle.transform.localRotation = startRoptation;
        }

        private void AnimationDoor()
        {
            if (openCloseON)
            {
                if (isOpen)
                {
                    if (openType == openTypeENUM.move_to_open)
                    {
                        if (doorAxis == doorAxisENUM.X)
                        {
                            float positonX = Mathf.MoveTowards(transform.localPosition.x, startDistanceOrAngle + openDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localPosition = new Vector3(positonX, transform.localPosition.y, transform.localPosition.z);
                            if(transform.localPosition.x == startDistanceOrAngle + openDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Y)
                        {
                            float positionY = Mathf.MoveTowards(transform.localPosition.y, startDistanceOrAngle + openDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localPosition = new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
                            if (transform.localPosition.y == startDistanceOrAngle + openDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Z)
                        {
                            float postionZ = Mathf.MoveTowards(transform.localPosition.z, startDistanceOrAngle + openDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, postionZ);
                            if (transform.localPosition.z == startDistanceOrAngle + openDistanceOrAngle) StopOpenDoor(); 
                        }
                    }
                    else
                    {
                        if (doorAxis == doorAxisENUM.X)
                        {
                            float angelX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, startDistanceOrAngle + openDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localEulerAngles = new Vector3(angelX, 0, 0);
                            if (transform.localEulerAngles.x == startDistanceOrAngle + openDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Y)
                        {
                            float angelY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, startDistanceOrAngle + openDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localEulerAngles = new Vector3(0, angelY, 0);
                            if (transform.localEulerAngles.y == startDistanceOrAngle + openDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Z)
                        {
                            float angelZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, startDistanceOrAngle + openDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localEulerAngles = new Vector3(0, 0, angelZ);
                            if (transform.localEulerAngles.z == startDistanceOrAngle + openDistanceOrAngle) StopOpenDoor();

                        }
                    }
                }
                else
                {
                    if (openType == openTypeENUM.move_to_open)
                    {
                        if (doorAxis == doorAxisENUM.X)
                        {
                            float positonX = Mathf.MoveTowards(transform.localPosition.x, startDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localPosition = new Vector3(positonX, transform.localPosition.y, transform.localPosition.z);
                            if (transform.localPosition.x == startDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Y)
                        {
                            float positionY = Mathf.MoveTowards(transform.localPosition.y, startDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localPosition = new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
                            if (transform.localPosition.y == startDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Z)
                        {
                            float postionZ = Mathf.MoveTowards(transform.localPosition.z, startDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, postionZ);
                            if (transform.localPosition.z == startDistanceOrAngle) StopOpenDoor();
                        }
                    }
                    else
                    {
                        if (doorAxis == doorAxisENUM.X)
                        {
                            float angelX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, startDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localEulerAngles = new Vector3(angelX, 0, 0);
                            if (transform.localEulerAngles.x == startDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Y)
                        {
                            float angelY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, startDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localEulerAngles = new Vector3(0, angelY, 0);
                            if (transform.localEulerAngles.y == startDistanceOrAngle) StopOpenDoor();
                        }
                        else if (doorAxis == doorAxisENUM.Z)
                        {
                            float angelZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, startDistanceOrAngle, openSpeed * Time.deltaTime);
                            transform.localEulerAngles = new Vector3(0, 0, angelZ);
                            if (transform.localEulerAngles.z == startDistanceOrAngle) StopOpenDoor();

                        }
                    }
                }
            }
        }

        private void OpenDoor()
        {
            if (canBeOpenedNow)
            {
                if (moveOrRotataionSound) moveOrRotataionSound.Play();
                openCloseON = true;
                //StartCoroutine(OpenAnimationDoor());
                if (isOpen) isOpen = false;
                else
                {
                    isOpen = true;
                    if(openSound) openSound.Play();
                    if(onlyOpen)
                    {
                        canBeOpenedNow = false;
                    }
                }
            }
            else
            {
                if (onlyOpen)
                    Debug.Log("Нельзя закрыть");
                else
                    Debug.Log("Закрыто");
                if (notOpeningSound) notOpeningSound.Play();

            }
        }

        private IEnumerator OpenAnimationDoor()
        {
            while (true)
            {
                AnimationDoor();
                yield return null;
                Debug.Log("work");
            }
        }

        private void Update()
        {
            AnimationDoor();
        }

        private void StopOpenDoor()
        {
            openCloseON = false;
            if (moveOrRotataionSound) moveOrRotataionSound.Stop();
            if (closeSound && !isOpen) closeSound.Play();
            //StopCoroutine(OpenAnimationDoor());
            Debug.Log("Stop");
        }
    }
}
