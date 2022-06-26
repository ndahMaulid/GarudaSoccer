using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter1 : MonoBehaviour
{
    public void playchapter1(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
