using System.Collections.Generic;

public class SignInteractable : BaseInteractable
{
    private static readonly List<string> MESSAGES = new List<string>()
    {
        "Hey buddy.",
        "How's it going?",
        "You doing alright?",
        "Oh that's good.",
        "Me?",
        "Oh I'm doing fine...for a sign.",
        "What do I mean?",
        "Well I just sit here and do nothing",
        "all...",
        "day...",
        "long..."
    };

    private int mCurrMsgIndex;

    void Awake()
    {
        mCurrMsgIndex = 0;
    }

    public override void OnInteract(Character character)
    {
        character.SetCanMove(false);
        if (mCurrMsgIndex == MESSAGES.Count)
        {
            OnEscape(character);
        } else
        {
            DialogBox.Show(MESSAGES[mCurrMsgIndex]);
            mCurrMsgIndex++;
        }
    }

    public override void OnEscape(Character character)
    {
        character.SetCanMove(true);
        DialogBox.Hide();
        mCurrMsgIndex = 0;
    }
}