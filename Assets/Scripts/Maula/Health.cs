using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] GameObject LoseCanvas;
  [SerializeField] float startingHealth = 3f;
  public static float currentHealth;
  public bool dead;

  void Awake()
  {
    if (currentHealth == 0)
    {
      currentHealth = startingHealth;
    }
  }

  public float GetCurrentHealth()
  {
    return currentHealth;
  }

  public void TakeDamage(float damage)
  {
    currentHealth = Mathf.Clamp(currentHealth - damage, 0f, startingHealth);

    if (currentHealth <= 0)
    {
      if (!dead)
      {
        dead = true;
        LoseCanvas.SetActive(true);
        FindObjectOfType<UIStartMenu>().Pause();
      }
    }
  }
}
