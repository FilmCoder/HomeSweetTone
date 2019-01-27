using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] dialoguePanels;
    public GameObject[] dialogueTexts;

    private bool[] isCharacterInScene;

    public enum CHARACTER {
        GIRL = 0,
        CAT = 1,
        LADY = 2,
        MAN = 3,
        PLAYER = 5
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
