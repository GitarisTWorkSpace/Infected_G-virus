using UnityEngine;

namespace Player
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private GameObject playerObject;
        [SerializeField] private SettingsControlModel settingsControll;

        [SerializeField] private float smoothTime;

        private float xRotation;
        private float yRotation;

        private float xRotationCurrent;
        private float yRotationCurrent;

        private float xVelosityCurrent;
        private float yVelosityCurrent;

        private void CameraRotation()
        {
            xRotation += Input.GetAxis("Mouse Y") * settingsControll.GetSensivity() * Time.deltaTime;
            yRotation += Input.GetAxis("Mouse X") * settingsControll.GetSensivity() * Time.deltaTime;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            xRotationCurrent = Mathf.SmoothDamp(xRotationCurrent, xRotation, ref xVelosityCurrent, smoothTime);
            yRotationCurrent = Mathf.SmoothDamp(yRotationCurrent, yRotation, ref yVelosityCurrent, smoothTime);

            playerCamera.transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0);
            playerObject.transform.rotation = Quaternion.Euler(0, yRotationCurrent, 0);
        }

        private void FixedUpdate()
        {
            CameraRotation();
        }
    }
}
