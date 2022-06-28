using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthball : MonoBehaviour
{
  Health health;
  [SerializeField] Image totalHealthbarImage;
  [SerializeField] Image currentHealthbarImage;

  void Awake()
  {
    health = FindObjectOfType<Health>();
  }

  void Start()
  {
    totalHealthbarImage.fillAmount = health.GetCurrentHealth() / 5f;
  }

  void Update()
  {
    currentHealthbarImage.fillAmount = health.GetCurrentHealth() / 5f;
  }
}