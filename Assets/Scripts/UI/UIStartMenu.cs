using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIStartMenu : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI coinText;
  [SerializeField] TextMeshProUGUI finalCoinText;
  GameObject maula;

  void Awake()
  {
    maula = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    if (coinText != null)
    {
      coinText.text = maula.GetComponent<MaulaScript>().totalCoin.ToString();
      finalCoinText.text = coinText.text;
    }
  }

  public void Exit()
  {
    Application.Quit();
  }
  public void Play(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
    if (Time.timeScale == 0)
    {
      Time.timeScale = 1;
    }
  }

  public void PlayAgain()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    if (Time.timeScale == 0)
    {
      Time.timeScale = 1;
    }
  }

  public void Pause()
  {

    Time.timeScale = 0;

  }

  public void Unpause()
  {
    Time.timeScale = 1;
  }

  //public void SoundVolume(float volume)
  //{
  //    PlayerPrefs.SetFloat("volume", volume);
  //}
}
