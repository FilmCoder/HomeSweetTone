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
        UserPromptObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasUserAnswered && Input.GetKeyDown("a"))
        {
            ChooseAnswer('a');
            return;
        }

        if (!_hasUserAnswered && Input.GetKeyDown("b"))
        {
            ChooseAnswer('b');
            return;
        }

        // TODO have answer be automically chosen after some time
    }

    public void GivePrompt(string optionA, string optionB, float secondsToAnswer = 6f, char defaultOption = 'a')
    {
        _hasUserAnswered = false;
        optionAText.text = optionA;
        optionBText.text = optionB;
        UserPromptObject.SetActive(true);
        Debug.Log("GivePrompt() completed.");
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
    }
}
