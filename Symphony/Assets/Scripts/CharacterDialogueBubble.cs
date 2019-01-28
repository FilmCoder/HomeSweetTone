using System.Collections;
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
    // entire speech bubble / dialogueBox object (UI element on a canvas), for toggling visible and invisible
    public GameObject speechBubble;
    // gameobject that the speech bubble should follow around
    public GameObject anchor;

    private Camera cam;
    private CanvasScaler canvasScaler;

    private void Start()
    {
        //nameText.text = specifiedName; // most of CharacterDialogueBubble logic moved into GameController,
          // but reusing it now in a hacky fashion to get bubbles to follow characters heads
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        canvasScaler = GameObject.FindWithTag("DialogueCanvas").GetComponent<CanvasScaler>();
    }

    private void Update()
    {
        Vector2 newAnchorPoint = cam.WorldToScreenPoint(anchor.transform.position);
        Vector2 scaleReference = new Vector2(canvasScaler.referenceResolution.x / Screen.width, canvasScaler.referenceResolution.y / Screen.height);
        newAnchorPoint.Scale(scaleReference);

        speechBubble.GetComponent<RectTransform>().anchoredPosition = newAnchorPoint;
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
