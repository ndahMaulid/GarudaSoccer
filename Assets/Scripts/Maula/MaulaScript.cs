using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaulaScript : MonoBehaviour
{
  public float jumpForce = 10f;
  public float respawnDelay = 1f;

  [SerializeField] bool isGrounded = false;

  Rigidbody2D rb;
  Transform ball;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("ground"))
    {
      if (!isGrounded)
      {
        isGrounded = true;
      }
    }

    if (collision.gameObject.CompareTag("obstackle"))
    {
      GetComponent<Health>().TakeDamage(1);
      StartCoroutine(Respawn(respawnDelay));
    }
  }
  public void Jump()
  {
    if (isGrounded)
    {
      rb.AddForce(Vector3.up * jumpForce);
      isGrounded = false;
    }
  }

  IEnumerator Respawn(float delay)
  {
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
