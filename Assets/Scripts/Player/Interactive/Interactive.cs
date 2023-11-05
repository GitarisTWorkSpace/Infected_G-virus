using Interactiv;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Interactive : MonoBehaviour
    {
        [SerializeField] private Camera playerMainCamera;
        [SerializeField] private float interactivDistance = 10f;

        [SerializeField] private TMP_Text interactionText;
        private bool isInteraciv;
        private void DoInteractiv(bool status) => isInteraciv = status;
        private void OnEnable()
        {
            InputManager.interactiveButtonCliked += DoInteractiv;
        }
        // Update is called once per frame
        void Update()
        {
            InteractivRay();
        }

        private void InteractivRay()
        {
            Ray ray = playerMainCamera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            bool isInteractable = false;

            if (Physics.Raycast(ray, out hit, interactivDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    isInteractable = true;
                    interactionText.text = interactable.GetDescription();

                    if (isInteraciv)
                    {
                        interactable.Interact();
                    }
                }                
            }

            if (!isInteractable) interactionText.text = "";
        }
    }
}
