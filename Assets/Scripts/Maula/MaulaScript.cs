using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaulaScript : MonoBehaviour
{
  public bool canJump;
  public float jumpAmount = 10f;
  public float totalCoin = 0f;
  [SerializeField] float runAmount = 2f;
  [SerializeField] float respawnTime = 3f;
  [SerializeField] float coinValue = 50f;
  Health health;

  Rigidbody2D rb;
  Animator animator;
  [SerializeField] GameObject WinCanvas;

  void Awake()
  {
    health = FindObjectOfType<Health>();
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  void FixedUpdate()
  {
    Run();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("ground"))
    {
      canJump = true;
      animator.SetBool("isJumping", false);
    }

    if (other.gameObject.CompareTag("obstackle"))
    {
      health.TakeDamage(1);
      StartCoroutine(Respawn());
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Finish"))
    {
      WinCanvas.SetActive(true);
      Time.timeScale = 0;
    }

    if (other.gameObject.CompareTag("coin"))
    {
      totalCoin += coinValue;
      Destroy(other.gameObject);
    }
  }

  void Run()
  {
    rb.velocity = new Vector2(runAmount, rb.velocity.y);
  }

  public void Jump()
  {
    if (canJump)
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
      animator.SetBool("isJumping", true);
      canJump = false;
    }
  }

  IEnumerator Respawn()
  {
    yield return new WaitForSeconds(respawnTime);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}