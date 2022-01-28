using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainScreen, tutorial;

    public void OnButtonPlayGame()
    {
        SceneManager.LoadScene("Stadium");
    }

    public void OnButtonTutorial()
    {
        mainScreen.SetActive(false);
        tutorial.SetActive(true);
    }

    public void OnButtonBack()
    {
        mainScreen.SetActive(true);
        tutorial.SetActive(false);
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }
    
}
