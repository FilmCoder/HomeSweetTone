using System.Collections;
using System.Collections.Generic;

///<summary>
/// Represents a single line of conversation said by a character at a certain time, for a certain duration.
///</summary>
public class ConversationLine
{
    public GameController.CHARACTER character {get; set;}
    public string text {get; set;}
    public bool keepPreviousText {get; set;} = false;
    public float duration {get; set;} = 1f;
    public float delay {get; set;}
    public bool hideOnExpire {get; set;} = true;
}
