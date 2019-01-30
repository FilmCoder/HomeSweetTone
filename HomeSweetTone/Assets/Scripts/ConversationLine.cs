using System.Collections;
using System.Collections.Generic;
using static GameController;

///<summary>
/// Represents a single line of conversation said by a character at a certain time, for a certain duration.
///</summary>
public class ConversationLine
{
    ///<summary>The character speaking.</summary>
    public CHARACTER character {get; set;}
    ///<summary>Text to show. If this is a dialogue choice, text for the first choice.</summary>
    public string text {get; set;}
    ///<summary>Whether or not this is a dialogue choice for the player.</summary>
    public bool isChoice {get; set;} = false;
    ///<summary>Text for the second dialogue choice, if applicable.</summary>
    public string text2 {get; set;}
    ///<summary>A single-line response to a player's up choice, if applicable.</summary>
    public ConversationLine response1 {get; set;}
    ///<summary>A single-line response to a player's down choice, if applicable.</summary>
    public ConversationLine response2 {get; set;}
    ///<summary>The character that is negatively affected by your choice.</summary>
    public CHARACTER affectedCharacter {get; set;}
    ///<summary>Whether or not to preserve any existing text.</summary>
    public bool keepPreviousText {get; set;} = false;
    ///<summary>How long this message appears for. Unused if !hideOnExpire.</summary>
    public float duration {get; set;} = 1f;
    ///<summary>Number of seconds from the start of the section before this line appears.</summary>
    public float delay {get; set;}
    ///<summary>Whether or not to dismiss the box after this line is said.</summary>
    public bool hideOnExpire {get; set;} = true;
}
