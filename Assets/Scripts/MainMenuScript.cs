using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject Settings_Panel;
    public GameObject Credits_Panel;
    public GameObject MainMenu_Panel;


    public void Start()
    {
        Settings_Panel.SetActive(false);
        Credits_Panel.SetActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        MainMenu_Panel.SetActive(true);
        Settings_Panel.SetActive(false);
        Credits_Panel.SetActive(false);
    }

    public void LoadSettings()
    {
        Settings_Panel.SetActive(true);
        MainMenu_Panel.SetActive(false);
    }
    public void LoadCredits()
    {
        Credits_Panel.SetActive(true);
        MainMenu_Panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
