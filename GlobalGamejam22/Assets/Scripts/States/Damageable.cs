using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] FloatVariable maxHealth;
    [SerializeField] FloatVariable health;
    [SerializeField] string damageTag;

    private void Start()
    {
        health.value = maxHealth.value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(collision);
    }
    public void TakeDamage(Collider2D collision)
    {
        if (collision.CompareTag(damageTag))
        {
            IDamaging damaging = collision.GetComponent<IDamaging>();
            if (damaging != null)
            {
                health.value -= damaging.GetDamage();
                if (health.value <= 0)
                {
                    Die();
                }
            }
        }
    }

    public void Die()
    {
        Debug.Log("YOU DIED");
    }
}
