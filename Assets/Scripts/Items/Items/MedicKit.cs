using Player.Inventory.Health;
using UnityEngine;

public class MedicKit : MonoBehaviour
{
    [SerializeField] private HealthModel healthModel;
    [SerializeField] private int medicKitIndex;
    [SerializeField] private int medicKitCount;

    public void SetMedicKitIndex(int index)
    {
        medicKitIndex = index;
    }

    public void SetMedicKitCount(int count)
    {
        medicKitCount = count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            healthModel.AddCountMedicKitByType(medicKitIndex, medicKitCount);
            Destroy(gameObject);
        }
    }
}
