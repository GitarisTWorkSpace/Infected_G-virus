using System;
using UnityEngine;

namespace Player.Inventory.Health
{
    [CreateAssetMenu(fileName = "Health", menuName = "Settings/Health")]
    public class HealthModel : ScriptableObject
    {
        public static Action<int> addedMedicKit;

        [SerializeField] private float maxPlayerHealthPoint;
        [SerializeField] private float playerHealthPoint;

        [SerializeField] private int[] medicKitByTypeAmount;
        [SerializeField] private float[] medicKitSetHealthPoint;
      
        public float GetMaxPlayerHealthPoint() => maxPlayerHealthPoint;
        public float GetPlayerHealthPoint() => playerHealthPoint;
        public int GetCountMedicKitType() => medicKitByTypeAmount.Length;
        public int GetCountMedicKit(int index) => medicKitByTypeAmount[index];
        public float GetMedicKitHealthPoint(int typeIndex) => medicKitSetHealthPoint[typeIndex];

        public void ReduceCountMedicKitByType(int typeIndex, int count) => medicKitByTypeAmount[typeIndex] -= count;
        public void AddCountMedicKitByType(int typeIndex, int count)
        {
            medicKitByTypeAmount[typeIndex] += count;
            addedMedicKit?.Invoke(typeIndex);
        }
        public void SetPlayerHealthPoint(float healthPoint) => playerHealthPoint = healthPoint;
    }
}
