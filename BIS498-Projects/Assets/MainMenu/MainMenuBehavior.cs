using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    public void PlayPrototype1()
    {
        SceneManager.LoadScene("Prototype1");
    }
    
    public void PlayPrototype2()
    {
        SceneManager.LoadScene("Prototype2");
    }

    public void PlayPrototype3()
    {
        SceneManager.LoadScene("Prototype3");
    }
    
    public void QuitApp()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
