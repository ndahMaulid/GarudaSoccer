using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHealth = 3f;
    public float currentHealth { get; private set; }
    public bool dead;



    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, startingHealth);

        if (currentHealth <= 0)
        {
            if (!dead)
            {
                dead = true;
            }
        }
    }
}
