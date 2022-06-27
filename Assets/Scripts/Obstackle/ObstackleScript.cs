using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstackleScript : MonoBehaviour
{
  [SerializeField] float speed = 0.1f;

  void FixedUpdate()
  {
    MoveLeft();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("obstackleDestroyer"))
    {
      Destroy(gameObject);
    }
  }

  void MoveLeft()
  {
    transform.position -= new Vector3(speed, 0, 0);
  }
}
