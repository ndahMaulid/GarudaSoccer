using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        Application.Quit();
    }
    public void play(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void sound_volume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume); 
    }
}
