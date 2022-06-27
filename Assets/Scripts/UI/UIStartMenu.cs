﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //public void SoundVolume(float volume)
    //{
    //    PlayerPrefs.SetFloat("volume", volume);
    //}
}
