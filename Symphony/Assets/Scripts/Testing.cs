using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Animator animator;
    private CharacterDialogueBubble dialogueBubble;
    private UserPrompt userPrompt;

    void Start()
    {
        dialogueBubble = GetComponent<CharacterDialogueBubble>();
        StartCoroutine("SayThings1");
        userPrompt = GameObject.FindWithTag("UserPrompt").GetComponent<UserPrompt>();
    }

    IEnumerator SayThings1()
    {
        Debug.Log("Kitty Dialogue begun");
        dialogueBubble.Say("I am the king kitty. Pet me or I'll cough a hairball onto a very clean place of yours.");
        yield return new WaitForSeconds(3);

        userPrompt.GivePrompt("Dawwwww, I'll give you pets soon you adorable little fluff ball.",
            "Hey Kitty, I know! Why don't you go pet yourself?!");

        while(!userPrompt.IsPromptAnswered())
        {
            yield return null;
        }

        char answer = userPrompt.GetAnswer();

        dialogueBubble.Say("I'm so cute, look at me purr. I'm going to make you so very dirty!");
        yield return  new WaitForSeconds(5);
        dialogueBubble.Hide();
    }

    void Update()
    {   
        // toggle inside/outside animation state
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("IsInside", !animator.GetBool("IsInside"));
            print("space key was pressed");
        }
    }
}
