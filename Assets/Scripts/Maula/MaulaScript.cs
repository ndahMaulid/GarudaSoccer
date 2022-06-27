using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaulaScript : MonoBehaviour
{
  public bool canJump;
  [SerializeField] float jumpAmount = 10f;
  Health health;

  void Awake()
  {
    health = FindObjectOfType<Health>();
  }


  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("ground"))
    {
      canJump = true;
    }

    if (other.gameObject.CompareTag("obstackle"))
    {
      health.TakeDamage(1);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }

  void Jump()
  {
    if (canJump)
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpAmount);
      canJump = false;
    }
  }
}
