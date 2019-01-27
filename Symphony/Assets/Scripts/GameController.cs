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
    public GameObject selectorPanel1;
    public GameObject selectorPanel2;
    private Text[] dialogueTexts = new Text[5];
    private Text choiceText1;
    private Text choiceText2;

    public AudioSource[] audioSources;
    private const float typingDelay = 0.02f;
    private const float choiceDisplayDuration = 3f;
    private const float LEAVE_THRESHOLD = -2;
    private const float AUDIO_FADE_INTERVAL = 0.02f;
    private const float AUDIO_FADE_TIME = 1f;

    ///<summary>
    /// Keeps track of which characters are on stage.
    ///</summary>
    private bool[] presentCharacters = new bool[]{false, true, false, false, true};

    private int[] attitudes = new int[5];

    private SECTION currentDialogueSection = SECTION.A;
    ///<summary>Keeps track of whether or not the player is currently making a choice.</summary>
    private bool isMakingChoice = false;
    ///<summary>Keeps track of the (binary) choice that a player makes in dialogues.</summary>
    private bool isUpSelected = true;

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
        SECTION nextSection = currentDialogueSection + 1;
        if (sectionDelays.Length > (int)nextSection && Time.time > sectionDelays[(int)nextSection]) {
            currentDialogueSection = nextSection;
            launchFirstValidConversation(conversationSections[(int)currentDialogueSection]);
        }

        if (!isMakingChoice) {
            // If the player is not making a choice right now, there's no need to bother with input handling.
            return;
        }
        if (isUpSelected && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))) {
            isUpSelected = false;
            selectorPanel1.SetActive(false);
            selectorPanel2.SetActive(true);
        } else if (!isUpSelected && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))) {
            isUpSelected = true;
            selectorPanel1.SetActive(true);
            selectorPanel2.SetActive(false);
        }
    }

    private void dismissCharacter(CHARACTER character) {
        if (!presentCharacters[(int)character]) {
            // This character isn't even here! Do nothing
            return;
        }
        presentCharacters[(int)character] = false;
        StartCoroutine(fadeAudioOut(character));
        // TODO Play animation.
    }

    private IEnumerator fadeAudioOut(CHARACTER character) {
        for (float time = 0f; time < AUDIO_FADE_TIME; time += Time.deltaTime) {
            audioSources[(int)character].volume = (AUDIO_FADE_TIME - time) / AUDIO_FADE_TIME;
            yield return new WaitForSeconds(AUDIO_FADE_INTERVAL);

        }
        audioSources[(int)character].volume = 0f;
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

        if (line.isChoice) {
            GameObject playerBox = dialogueBoxes[(int)CHARACTER.PLAYER];
            // Hide the player's box until they make a choice.
            playerBox.SetActive(false);
            promptBox.SetActive(true);
            isUpSelected = true;
            isMakingChoice = true;
            selectorPanel1.SetActive(true);
            selectorPanel2.SetActive(false);
            StartCoroutine(typeSentence(choiceText1, line.text, line.keepPreviousText));
            StartCoroutine(typeSentence(choiceText2, line.text2, line.keepPreviousText));
            yield return new WaitForSeconds(line.duration);
            isMakingChoice = false;
            playerBox.SetActive(true);
            promptBox.SetActive(false);
            StartCoroutine(launchLine(isUpSelected ? line.response1 : line.response2));
            StartCoroutine(typeSentence(dialogueTexts[(int)line.character], isUpSelected ? line.text : line.text2));
            attitudes[(int)line.affectedCharacter] += isUpSelected ? 0 : -1;
            if (attitudes[(int)line.affectedCharacter] <= LEAVE_THRESHOLD) {
                dismissCharacter(line.affectedCharacter);
            }
            yield return new WaitForSeconds(choiceDisplayDuration);
            playerBox.SetActive(false);
            yield break;
        }

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
