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
					delay = 7.5f,
					hideOnExpire = false,
					text = "Wish I didn't have to move so far away though."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 12f,
					duration = 4f,
					text = "I really miss home. Maybe I can come visit sometime--"
				}
			}
		};
		conversations[(int)SECTION.C] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 3f,
					duration = 5f,
					text = "Hey there! Mind if I join you?"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 4f,
					duration = 8f,
					isChoice = true,
					text = "Sure thing! Thanks for stopping by.",
					text2 = "Actually, I'm really busy right now...",
					response1 = new ConversationLine {
						character = CHARACTER.GIRL,
						delay = 3f,
						duration = 3f,
						text = "Great! Still working on your game?"
					},
					response2 = new ConversationLine {
						character = CHARACTER.GIRL,
						delay = 3f,
						duration = 3f,
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
					text = "Meow?"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					duration = 8f,
					isChoice = true,
					text = "Good kitty! You're adorable.",
					text2 = "Shoo! Bad cat!",
					response1 = new ConversationLine {
						character = CHARACTER.CAT,
						delay = 3f,
						duration = 2f,
						text = "Meow. :3"
					},
					response2 = new ConversationLine {
						character = CHARACTER.CAT,
						delay = 3f,
						duration = 2f,
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
					text = "Meow?"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					duration = 6f,
					isChoice = true,
					text = "You can stay, but don't get in the way!",
					text2 = "Go away, you hideous beast.",
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
		conversations[(int)SECTION.F] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 4f,
					text = "He's so fluffy I'm gonna dieee"
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 3f,
					hideOnExpire = false,
					text = "How ya doing Mr. Kitty?"
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 5f,
					duration = 2f,
					text = "Meow."
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 7f,
					duration = 3f,
					text = "Ahhh. Interesting. Why do you feel that way?"
				},
                new ConversationLine {
                    character = CHARACTER.CAT,
                    delay = 9f,
                    duration = 3f,
                    text = "MREEEOOOOW!!!!!!"
                },
                new ConversationLine {
                    character = CHARACTER.GIRL,
                    delay = 11f,
                    duration = 6f,
                    text = "Oh GEEZ sorry! Didn't realize it was such a personal matter for you."
                },
            },
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 1f,
					duration = 2f,
					text = "Meow."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 4f,
					duration = 4f,
					text = "Meow meow meow."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 7f,
					duration = 4f,
					text = "Shh! I'm working here, Mister."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 11f,
					duration = 4f,
					text = "Meow... >_<"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 15f,
					duration = 3f,
					text = "...Hm?"
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 4f,
					text = "Aw, why did you chase him away?"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 5f,
					duration = 3f,
					text = "I'm allergic."
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 8f,
					hideOnExpire = false,
					text = "Oh. "
				},
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 10f,
					duration = 5f,
					keepPreviousText = true,
					text = "Well I guess we don't need a cat around..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 15f,
					duration = 3f,
					text = "...Hm?"
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					hideOnExpire = false,
					text = "Phew. Scared that ugly cat away."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 5f,
					duration = 3.5f,
					text = "Now, where was I..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 9f,
					hideOnExpire = false,
					text = "...beep boop beep..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 12f,
					keepPreviousText = true,
					duration = 2.5f,
					text = "\n...[furious typing]..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 15f,
					keepPreviousText = true,
					duration = 3f,
					text = "...Hm?"
				},
			}
		};
		conversations[(int)SECTION.G] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 4.5f,
					duration = 2.5f,
					text = "Hey."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 5.5f,
					duration = 2.5f,
					text = "Hey sis."
				},
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 7.5f,
					duration = 4f,
					text = "Have you talked to Mom yet?"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 9f,
					duration = 2.5f,
					text = "Not yet."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					isChoice = true,
					delay = 11f,
					duration = 8f,
					text = "Do you want to hang out for a while?",
					text2 = "Listen, can we do this later?",
					response1 = new ConversationLine {
						character = CHARACTER.LADY,
						delay = 1f,
						duration = 3f,
						text = "Sure thing."
					},
					response2 = new ConversationLine {
						character = CHARACTER.LADY,
						delay = 3f,
						duration = 2.5f,
						text = "Ok. I'll head back then..."
					},
					affectedCharacter = CHARACTER.LADY
				},
			}
		};
		conversations[(int)SECTION.H] = new List<List<ConversationLine>> {
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 3f,
					text = "Hi there! I'm Grace."
				},
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 4f,
					duration = 3f,
					text = "Ada. Nice to meet you."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 6f,
					duration = 3f,
					text = "Meow? ^o^"
				},
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 8f,
					duration = 3f,
					text = "Sweet cat."
				},
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 4f,
					text = "She seemed nice..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 5f,
					duration = 4f,
					text = "Eh, she's alright."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 9f,
					duration = 2f,
					text = "Meow..."
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.GIRL,
					delay = 1f,
					duration = 4f,
					text = "She seemed nice..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 5f,
					duration = 4f,
					text = "Eh, she's alright."
				}
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 1f,
					duration = 4f,
					text = "Are you a good kitty?"
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 5f,
					duration = 3f,
					text = "Meow! :P"
				},
				new ConversationLine {
					character = CHARACTER.LADY,
					delay = 8f,
					duration = 4f,
					text = "Yes, yes you are."
				},
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					duration = 4f,
					text = "It's just you and me, Mister."
				},
				new ConversationLine {
					character = CHARACTER.CAT,
					delay = 5f,
					duration = 3f,
					text = "Meow. :("
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 8f,
					duration = 4f,
					text = "I'll pet you in a bit..."
				},
			},
			new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 2f,
					hideOnExpire = false,
					text = "Phew... "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "Hopefully that was the last of them."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 8f,
					duration = 2.5f,
					hideOnExpire = false,
					text = "...type type type..."
				}
			}
		};
		return conversations;
	}

	public static List<ConversationLine> getFinaleConversation(int score) {
		List<ConversationLine> conversation = new List<ConversationLine>();
		if (score == 0) {
			// Best ending - nobody is mad at you.
			conversation = new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					hideOnExpire = false,
					text = "Dear Mom,"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\nHonestly, I'm starting to like it here."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 8f,
					hideOnExpire = false,
					text = "I've been making some friends..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 12.5f,
					hideOnExpire = false,
					text = "And oddly enough, this place is starting to..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 16.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\nfeel "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 18.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "like... "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 21.5f,
					hideOnExpire = false,
					text = "Home."
				}
			};
		} else if (score > -3) {
			// Meh ending - You have 1 or 2 friends.
			conversation = new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					hideOnExpire = false,
					text = "Dear Mom,"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\nHonestly, I'm starting to like it here."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 8f,
					hideOnExpire = false,
					text = "I got to know a few people..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 12.5f,
					hideOnExpire = false,
					text = "And weirdly enough, this place is..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 16.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\nalmost "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 18.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "like... "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 21.5f,
					hideOnExpire = false,
					text = "Home."
				}
			};
		} else {
			// Bad ending - You have no friends. Womp womp.
			conversation = new List<ConversationLine> {
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 1f,
					hideOnExpire = false,
					text = "Dear Mom,"
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 3f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\nHonestly, I'm don't really like it here."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 8f,
					hideOnExpire = false,
					text = "I don't know anyone."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 12.5f,
					hideOnExpire = false,
					text = "And sure enough, I just want to..."
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 16.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "\nbe "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 18.5f,
					hideOnExpire = false,
					keepPreviousText = true,
					text = "back... "
				},
				new ConversationLine {
					character = CHARACTER.PLAYER,
					delay = 21.5f,
					hideOnExpire = false,
					text = "Home."
				}
			};
		}
		return conversation;
	}

}
