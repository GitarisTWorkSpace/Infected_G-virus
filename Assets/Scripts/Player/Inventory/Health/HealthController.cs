using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Inventory.Health
{
    public class HealthController : MonoBehaviour, IDamageable
    {
        public static Action playerHealthPointsChanged;
        public static Action<int> activMedicKitChanged;
        public static Action<int> medicKitUsed;

        [SerializeField] private HealthModel model;
        [SerializeField] private SettingsControlModel settings;

        [SerializeField] private float playerHealthPoints;

        [SerializeField] private int activeMedicKit;

        private void Start()
        {
            playerHealthPoints = model.GetMaxPlayerHealthPoint();
            model.SetPlayerHealthPoint(playerHealthPoints);
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0) return;
            playerHealthPoints -= damage;
            CheckPlayerHealthPoints();
            model.SetPlayerHealthPoint(playerHealthPoints);
            playerHealthPointsChanged?.Invoke();
        }

        private void CheckPlayerHealthPoints()
        {
            if (playerHealthPoints < 0) playerHealthPoints = 0;
            if (playerHealthPoints > model.GetMaxPlayerHealthPoint()) playerHealthPoints = model.GetMaxPlayerHealthPoint();
        }

        private void SwichActivMedicKit()
        {
            if (Input.GetKeyDown(settings.GetChangeMedicKitButton()))
            {
                activeMedicKit++;
                if(activeMedicKit >= model.GetCountMedicKitType())
                    activeMedicKit = 0;
                activMedicKitChanged?.Invoke(activeMedicKit);
            }
        }

        private void UseMedicKit()
        {
            if (Input.GetKeyDown(settings.GetUseMedicKitButton()))
            {
                if (model.GetCountMedicKit(activeMedicKit) > 0 && !(playerHealthPoints == model.GetMaxPlayerHealthPoint()))
                {
                    model.ReduceCountMedicKitByType(activeMedicKit, 1);
                    playerHealthPoints += model.GetMedicKitHealthPoint(activeMedicKit);
                    CheckPlayerHealthPoints();
                    model.SetPlayerHealthPoint(playerHealthPoints);
                    playerHealthPointsChanged?.Invoke();
                    medicKitUsed?.Invoke(activeMedicKit);
                }
            }
        }

        private void Update()
        {
            SwichActivMedicKit();
            UseMedicKit();
        }
    }
}
