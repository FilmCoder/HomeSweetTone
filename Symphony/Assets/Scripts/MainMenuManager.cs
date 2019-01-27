using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public Button startButton, creditsButton;

    public void Start()
    {
        startButton.onClick.AddListener(startGame);
        creditsButton.onClick.AddListener(rollCredits);
    }

    public void rollCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
