using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  static AudioPlayer instance;

  void Awake()
  {
    ManageSingleton();
  }

  void ManageSingleton()
  {
    if (instance != null)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  public void TurnOffAudio()
  {
    GetComponent<AudioSource>().enabled = false;
  }

  void PlayClip(AudioClip clip, float volume)
  {
    if (clip != null)
    {
      Vector3 pos = Camera.main.transform.position;
      AudioSource.PlayClipAtPoint(clip, pos, volume);
    }
  }

  [Header("Click")]
  [SerializeField] AudioClip click;
  [SerializeField][Range(0f, 1f)] float clickVolume = 1f;

  public void PlayClickClip()
  {
    PlayClip(click, clickVolume);
  }
}
