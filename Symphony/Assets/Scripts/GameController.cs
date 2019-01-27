using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] dialogueBoxes;
    public GameObject[] dialoguePanels;
    public GameObject promptBox;
    public GameObject choicePanel1;
    public GameObject choicePanel2;
    private Text[] dialogueTexts = new Text[5];
    private Text choiceText1;
    private Text choiceText2;

    public AudioSource[] audioSources;
    private const float typingDelay = 0.02f;

    ///<summary>
    /// Keeps track of which characters are on stage.
    ///</summary>
    private bool[] presentCharacters = new bool[]{false, false, false, false, true};

    private SECTION currentDialogueSection = SECTION.A;

	public static readonly float[] sectionDelays = new float[] {
		0f,
		16f,
		35f,
		51f,
		68f
	};

	public enum SECTION {
		A,
		B,
		C,
		D,
		E
	}

    public enum CHARACTER {
        GIRL = 0,
        CAT = 1,
        LADY = 2,
        MAN = 3,
        PLAYER = 4
    }

    private List<List<ConversationLine>>[] conversationSections;

    void Start()
    {
        // We fetch all Text components now so that we don't have to keep fetching them later.
        foreach (CHARACTER character in Enum.GetValues(typeof(CHARACTER))) {
            dialogueTexts[(int)character] = dialoguePanels[(int)character].GetComponent<Text>();
        }
        choiceText1 = choicePanel1.GetComponent<Text>();
        choiceText2 = choicePanel2.GetComponent<Text>();

        foreach (GameObject panel in dialogueBoxes) {
            panel.SetActive(false);
        }
        conversationSections = DialogueLoader.conversationsBySection();

        launchFirstValidConversation(conversationSections[(int)currentDialogueSection]);
    }

    void Update()
    {
        SECTION nextSection = currentDialogueSection;
        nextSection++;
        if (Time.time > sectionDelays[(int)nextSection]) {
            currentDialogueSection = nextSection;
            launchFirstValidConversation(conversationSections[(int)currentDialogueSection]);
        }
    }

    ///<summary>
    ///</summary>
    private void launchFirstValidConversation(List<List<ConversationLine>> conversationList) {
        foreach (List<ConversationLine> conversation in conversationList) {
            if (launchConversation(conversation)) {
                print($"Launched a conversation! (section {currentDialogueSection})");
                return;
            }
        }
    }

    ///<summary>
    /// Starts a conversation (if all required characters are present) by launching all of its lines simultaneously.
    /// (The lines each have their own delay, so they won't all pop up at once).
    ///</summary>
    ///<returns>sdf</returns>
    private bool launchConversation(List<ConversationLine> conversation) {
        if (!canHaveConversation(conversation)) {
            return false;
        }
        foreach (ConversationLine line in conversation) {
            StartCoroutine(launchLine(line));
        }
        return true;
    }

    ///<summary>
    /// Shows the dialogue box for a character, types out the line, and eventually hides the box.
    ///</summary>
    private IEnumerator launchLine(ConversationLine line) {
        yield return new WaitForSeconds(line.delay);
        GameObject panel = dialogueBoxes[(int)line.character];
        panel.SetActive(true);

        // Since typing takes its own time, we'll start it as a separate coroutine.
        StartCoroutine(typeSentence(dialogueTexts[(int)line.character], line.text, line.keepPreviousText));

        if (line.hideOnExpire) {
            // Once the line's duration is finished, hide the box.
            yield return new WaitForSeconds(line.duration);
            panel.SetActive(false);
        }
    }

    ///<summary>
    /// Types out a sentence on the given Text object.
    ///</summary>
    private IEnumerator typeSentence(Text text, string sentence, bool keepPreviousText = false)
    {
        // types out the letters one by one
        text.text = keepPreviousText? text.text : "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingDelay);
        }
    }

    ///<summary>
    /// Checks a list of lines to see if all the characters in those lines are present.
    ///</summary>
    public bool canHaveConversation(List<ConversationLine> lines) {
        foreach (ConversationLine line in lines) {
            if (!presentCharacters[(int)line.character]) {
                return false;
            }
        }
        return true;
    }


}
