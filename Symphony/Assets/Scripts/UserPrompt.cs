using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserPrompt : MonoBehaviour
{
    public Text optionAText;
    public Text optionBText;
    public GameObject UserPromptObject;

    private bool _hasUserAnswered = true;
    private char answer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasUserAnswered && Input.GetKeyDown("a"))
        {
            _hasUserAnswered = true;
            answer = 'a';
        }

        if (!_hasUserAnswered && Input.GetKeyDown("b"))
        {
            _hasUserAnswered = true;
            answer = 'b';
        }
    }

    //  GivePrompt(prompt text, timeToAnswer, defaultOption, optionA, optionB) ->

    public void GivePrompt(string optionA, string optionB, float secondsToAnswer = 6f, char defaultOption = 'a')
    {
        _hasUserAnswered = false;
        optionAText.text = optionA;
        optionBText.text = optionB;
        UserPromptObject.SetActive(true);
    }

    public bool IsPromptAnswered()
    {
        // TODO add in time, so it gets answered automatically after a set amount of time
        return _hasUserAnswered;
    }

    public char GetAnswer()
    {
        if (IsPromptAnswered())
        {
            return answer;
        } else
        {
            throw new System.Exception("You should not call GetAnswer before an answer has been decided.");
        }
    }
}
