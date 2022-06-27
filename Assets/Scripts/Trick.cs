using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trick : MonoBehaviour
{
  [SerializeField] Button trickButton;
  GameObject maula;

  void Awake()
  {
    maula = GameObject.FindGameObjectWithTag("Player");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      trickButton.interactable = true;
    }
  }

  public void PlayTrick()
  {
    maula.GetComponent<Rigidbody2D>().velocity = new Vector2(maula.GetComponent<Rigidbody2D>().velocity.x, maula.GetComponent<MaulaScript>().jumpAmount);
    maula.GetComponentInParent<Animator>().SetTrigger("isTricking");
    trickButton.interactable = false;
    Destroy(gameObject);
  }
}
