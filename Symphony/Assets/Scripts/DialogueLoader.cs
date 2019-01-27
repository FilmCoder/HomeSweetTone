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
					delay = 1f,
					hideOnExpire = false,
					text = "RE:Answer my calls!"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\n-- Hey Mom, I'm doing fine."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 6.5f,
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
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 5f,
					text = "Hey there! Mind if I join you?"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					duration = 8f,
					isChoice = true,
					text = "Sure thing! Thanks for stopping by.",
					text2 = "Actually, I'm really busy right now...",
					response1 = new ConversationLine {
						character = CHARACTER.GIRL,
						delay = 3f,
						duration = 4f,
						text = "Great! Still working on your game?"
					},
					response2 = new ConversationLine {
						character = CHARACTER.GIRL,
						delay = 3f,
						duration = 4f,
						text = "Oh, ok... Well, see you around!"
					}
				},
			}
		};
		conversations[(int)SECTION.D] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					duration = 4f,
					text = "Yeah... It's almost finished, but it needs a little more work."
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 5f,
					hideOnExpire = false,
					text = "Cool! You know I'll be the first in line to play it!"
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 9f,
					hideOnExpire = false,
					text = "I'm working on a project too, but it's a secret! :)"
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 13.5f,
					duration = 3f,
					text = "Wait, someone's coming!"
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 2f,
					duration = 4f,
					text = "Alright. Time to get back to work..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 7f,
					hideOnExpire = false,
					text = "...type type type..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 10f,
					keepPreviousText = true,
					duration = 2.5f,
					text = "\n...type type type..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 13f,
					duration = 4f,
					text = "What's this?"
				}
			}
		};
		conversations[(int)SECTION.E] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 1f,
					hideOnExpire = false,
					text = "Meow. (Pet me!)"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					duration = 8f,
					isChoice = true,
					text = "Okay. You're adorable!",
					text2 = "No, bad cat! I'm busy.",
					response1 = new ConversationLine {
						character = CHARACTER.CAT,
						delay = 3f,
						duration = 3f,
						text = "Meow. :3"
					},
					response2 = new ConversationLine {
						character = CHARACTER.CAT,
						delay = 3f,
						duration = 3f,
						text = "Meow... :("
					},
					affectedCharacter = CHARACTER.CAT
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 5f,
					duration = 4f,
					text = "Aw, he's so cute! HEY KITTY :D"
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 1f,
					hideOnExpire = false,
					text = "Meow. (Pet me!)"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					duration = 6f,
					isChoice = true,
					text = "Okay. You're super cute!",
					text2 = "No. You ugly.",
					response1 = new ConversationLine {
						character = CHARACTER.CAT,
						delay = 3f,
						duration = 3f,
						text = "Meow. :3"
					},
					response2 = new ConversationLine {
						character = CHARACTER.CAT,
						delay = 3f,
						duration = 3f,
						text = "Meow... :("
					},
					affectedCharacter = CHARACTER.CAT
				}
			}
		};
		return conversations;
	}

}
