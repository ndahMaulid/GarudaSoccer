using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaulaScript : MonoBehaviour
{
    public float jumpForce = 1000f;
    public float moveForce = 25f;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }

        Run();
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

        if (collision.gameObject.CompareTag("obstackle")) {
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
    void Run()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.right * moveForce);
        }
    }

    IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
