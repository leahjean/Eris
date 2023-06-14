using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Events.EventTypes;
using Assets.Scripts.UI;
using Assets.Scripts.Player;

namespace Assets.Scripts.Events
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject HUD;
        [SerializeField]
        private PlayerBaseControl mPlayerController;

        private DialogManager mDialogManager;

        private readonly Queue<GameEvent> mEventQueue = new Queue<GameEvent>();

        private void Start()
        {
            mDialogManager = HUD.GetComponentInChildren<DialogManager>();
        }

        void Update()
        {
            while (mEventQueue.Count > 0)
            {
                GameEvent gameEvent = mEventQueue.Dequeue();
                switch(gameEvent)
                {
                    case StartDialogEvent startDialogEvent:
                        mDialogManager.InitDialog(startDialogEvent.mDialog);
                        mPlayerController.SetCanMove(false);
                        return;
                    case EndDialogEvent _:
                        mPlayerController.SetCanMove(true);
                        return;
                    default:
                        return;
                }
            }
        }

        public void PublishEvent(GameEvent gameEvent)
        {
            mEventQueue.Enqueue(gameEvent);
        }
    }
}