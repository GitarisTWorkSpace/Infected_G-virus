using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    [SerializeField] private GameObject Item;

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            Instantiate(Item, transform.position, Quaternion.identity, transform);
        }
    }
}
