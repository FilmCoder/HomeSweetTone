using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class DialogueLoader
{
    public static List<List<ConversationLine>>[] conversationsBySection() {
		var conversations = new List<List<ConversationLine>>[Enum.GetValues(typeof(SECTION)).Length];
		conversations[(int)SECTION.A] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					hideOnExpire = false,
					text = "Another weekend all to myself!"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 5f,
					hideOnExpire = false,
					text = "I should keep working on this game..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 10f,
					duration = 4f,
					text = "Before I start, I should let Mom know I'm alright."
				}
			}
		};
		conversations[(int)SECTION.B] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 0f,
					hideOnExpire = false,
					text = "RE:Answer my calls!"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 2.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "Hey Mom, I'm doing fine."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 6f,
					hideOnExpire = false,
					text = "Wish I didn't have to move so far away though."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 11f,
					duration = 4f,
					text = "I really miss home. Maybe I can come visit sometime--"
				}
			}
		};
		conversations[(int)SECTION.C] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 1f,
					duration = 3f,
					text = "I know you can hear me. Meow."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 5f,
					duration = 3f,
					hideOnExpire = false,
					text = "Stop ignoring me! Meow."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 9f,
					duration = 3f,
					text = "...Meow?"
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 3f,
					text = "Hey Man!"
				},
				new ConversationLine {
					character = CHARACTER.MAN,
					delay = 5f,
					duration = 3f,
					hideOnExpire = false,
					text = "Sup girl ._."
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 9f,
					duration = 3f,
					text = "...Meow?"
				}
			}
		};
		conversations[(int)SECTION.D] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 1f,
					duration = 4f,
					text = "Pet me, Ada! You know you want to. Meow."
				},
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 5f,
					duration = 4f,
					text = "No thanks. You're stinky and ugly."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 9f,
					duration = 4f,
					text = "Meow... >.<"
				}
			}
		};
		return conversations;
	}

}
