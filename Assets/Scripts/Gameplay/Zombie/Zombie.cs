using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IDamageble
{
    [SerializeField] private float damage;
    public void TakeDamage(float damage)
    {
        Debug.Log("take damage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageble>() != null)
        {
            other.GetComponent<IDamageble>().TakeDamage(damage);
        }
    }
}
