using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Button playButton;
    public Button creditsButton;
    public Button backButton;
    public Button exitButton;

    public GameObject initialPanel;
    public GameObject creditsPanel;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        HideCreditsPanel();
        playButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(ShowCreditsPanel);
        backButton.onClick.AddListener(HideCreditsPanel);
        exitButton.onClick.AddListener(ExitGame);
    }

    void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
        initialPanel.SetActive(false);
    }

    void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
        initialPanel.SetActive(true);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
