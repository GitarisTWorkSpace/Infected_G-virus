using UnityEngine;

public class SetTime : MonoBehaviour
{
    [SerializeField] private GameObject Light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Light.transform.rotation = Quaternion.Euler(270, -30, 0);
            Destroy(gameObject);
        }
    }
}
