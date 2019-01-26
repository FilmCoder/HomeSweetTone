using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogueBubble : MonoBehaviour
{
    // actual name that will be used for this dialogue bubble
    public Text specifiedName;

    // UI.Text
    public Text nameText;
    public Text dialogueText;

    // entire speech bubble / dialogueBox object, for toggling visible and invisible
    public 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // say 
    public void Say(string text)
    {
        // TODO animate text, so characters appear one after another
        dialogueText.text = text;
    }

    // show

    // hide
}
