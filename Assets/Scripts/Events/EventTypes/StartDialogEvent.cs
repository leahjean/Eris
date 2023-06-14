using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Events.EventTypes
{
    public class StartDialogEvent : GameEvent 
    {
        public List<DialogParams> mDialog { get; private set; }

        public StartDialogEvent(List<DialogParams> dialog)
        {
            mDialog = dialog;
        }

        public class DialogParams
        {
            public string mSpeakerName { get; private set; }
            public string mDialogText { get; private set; }
            public UI.PortraitId mPortraitSpriteId { get; private set; }

            public DialogParams(string speakerName, string dialogText, UI.PortraitId portraitSpriteId)
            {
                mSpeakerName = speakerName;
                mDialogText = dialogText;
                mPortraitSpriteId = portraitSpriteId;
            }
        }
    }
}