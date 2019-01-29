using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public Button startButton, creditsButton;
    public GameObject[] menuSelectionOverlays;
    public AudioSource selectAudioSource;

    int selectionIndex = 0;
    // actual game (not main menu) can take a while to load. So we begin loading in immediately in async, so that
    // when user actually presses start button, game can start right away
    AsyncOperation asyncLoadGame;

    int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public void Start()
    {
        StartCoroutine(LoadGameAsync());
    }

    public void Update()
    {
        // set new index if up or down key is pressed
        if(Input.GetKeyDown("down"))
        {
            selectionIndex++;
        }
        if(Input.GetKeyDown("up"))
        {
            selectionIndex--;
        }
        selectionIndex = mod(selectionIndex, 3);

        // ensure proper overlay box is highlighted
        for(int i=0; i<=2; i++)
        {
            Debug.Log("Set Inactive: " + i);
            menuSelectionOverlays[i].SetActive(false);
        }
        menuSelectionOverlays[selectionIndex].SetActive(true);

        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            selectAudioSource.Play();
            switch (selectionIndex)
            {
                case 0:
                    // allow game to load once async load operation is done.
                    // if it's already done loading, this will start the game immediately
                    asyncLoadGame.allowSceneActivation = true;
                    break;
                case 1:
                    SceneManager.LoadScene("About");
                    break;
                case 2:
                    SceneManager.LoadScene("Credits");
                    break;
            }
        }
    }

    IEnumerator LoadGameAsync()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        asyncLoadGame = SceneManager.LoadSceneAsync("Game");
        asyncLoadGame.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoadGame.isDone)
        {
            yield return null;
        }
    }
}
