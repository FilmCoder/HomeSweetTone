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
    private float secondsSinceStartOfPrompt; // how long it's been since user was posed a question
    private float secondsToAnswer; // how long user has to answer question before its chosen for him
    private char defaultOption;

    // Start is called before the first frame update
    void Start()
    {
        UserPromptObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_hasUserAnswered)
        {
            secondsSinceStartOfPrompt += Time.deltaTime;

            if (Input.GetKeyDown("a"))
            {
                ChooseAnswer('a');
            }
            else if (Input.GetKeyDown("b"))
            {
                ChooseAnswer('b');
            }
            else if (secondsSinceStartOfPrompt >= secondsToAnswer)
            {
                ChooseAnswer(defaultOption);
            }
        }
    }

    public void GivePrompt(string optionA, string optionB, float _secondsToAnswer = 10f, char _defaultOption = 'a')
    {
        _hasUserAnswered = false;
        optionAText.text = optionA;
        optionBText.text = optionB;
        secondsSinceStartOfPrompt = 0f;
        secondsToAnswer = _secondsToAnswer;
        defaultOption = _defaultOption;
        UserPromptObject.SetActive(true);
    }

    public bool IsPromptAnswered()
    {
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

    private void ChooseAnswer(char chosen_answer)
    {
        _hasUserAnswered = true;
        answer = chosen_answer;
        UserPromptObject.SetActive(false); // hide the prompt after answer has been chosen
        Debug.Log("Answer chosen: " + chosen_answer);
    }
}
