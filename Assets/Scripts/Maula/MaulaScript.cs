using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

  int countDown = 3;
  [SerializeField] TextMeshProUGUI countdownText;
  bool isStart = false;
  bool isCoroutineRun = false;

  GameObject[] checkpoints;
  int currentCheckpoint = 0;

  void Awake()
  {
    health = FindObjectOfType<Health>();
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
  }

  void Update()
  {
    if (isStart)
    {
      Run();
      if (checkpoints.Length > 0 && checkpoints[currentCheckpoint + 1] != null)
      {
        if (transform.position.x > checkpoints[currentCheckpoint + 1].transform.position.x)
        {
          currentCheckpoint++;
        }
      }

    }
    else
    {
      if (!isCoroutineRun)
      {
        StartCoroutine(Countdown());
      }
    }
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
    isStart = false;
    transform.position = checkpoints[currentCheckpoint].transform.position;
  }

  IEnumerator Countdown()
  {
    countDown = 3;
    isCoroutineRun = true;
    countdownText.gameObject.SetActive(true);
    while (countDown > 0)
    {
      countdownText.text = countDown.ToString();
      yield return new WaitForSeconds(1f);
      countDown--;
    }

    countdownText.text = "GO!";

    yield return new WaitForSeconds(1f);
    countdownText.gameObject.SetActive(false);
    isStart = true;
    isCoroutineRun = false;
  }
}