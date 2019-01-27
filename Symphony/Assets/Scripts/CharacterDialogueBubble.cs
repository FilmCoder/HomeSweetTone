﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// attach this script to a character manager.
// then, hook it up the proper dialogue box / text,
// and THEN the Show, Hide, and Say functions can be 
// called from another script
public class CharacterDialogueBubble : MonoBehaviour
{
    // actual name that will be used for this dialogue bubble
    public string specifiedName;

    // UI.Text
    public Text nameText;
    public Text dialogueText;

    // entire speech bubble / dialogueBox object, for toggling visible and invisible
    public GameObject speechBubble;

    // gameobject that the speech bubble should follow around
    private GameObject anchor;

    private void Start()
    {
        nameText.text = specifiedName;
        anchor = gameObject;
    }

    // say some text
    public void Say(string sentence)
    {
        Show();
        StartCoroutine(TypeSentence(sentence));
    }

    // shows the speech bubble
    public void Show()
    {
        speechBubble.SetActive(true);
    }

    // hides the speech bubble
    public void Hide()
    {
        speechBubble.SetActive(false);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        // types out the letters one by one
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}