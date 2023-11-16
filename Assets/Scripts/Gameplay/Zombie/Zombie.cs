using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour, IDamageable
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float healthPoints;

    public float GetCurrentHealh() => healthPoints;

    private void Start()
    {
        healthSlider.maxValue = healthPoints;
        healthSlider.value = healthPoints;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        healthPoints -= damage;
        healthSlider.value = healthPoints;
        if (healthPoints <= 0) Destroy(gameObject);
    }
}
