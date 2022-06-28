using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHandler : MonoBehaviour
{
  [SerializeField] GameObject ExitPanel;
  void Update()
  {
    if (Input.GetKey(KeyCode.Escape))
    {
      ExitPanel.SetActive(true);
    }
  }
}
