using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public Button startButton, creditsButton;
    public GameObject[] menuSelectionOverlays;

    private int selectionIndex = 0;

    int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public void Start()
    {
        // startButton.onClick.AddListener(startGame);
        // creditsButton.onClick.AddListener(rollCredits);
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
            switch(selectionIndex)
            {
                case 0:
                    SceneManager.LoadScene("SampleScene");
                    break;
                case 1:
                    SceneManager.LoadScene("About");
                    break;
                case 2:
                    SceneManager.LoadScene("Credits ");
                    break;
            }
        }
    }
}
