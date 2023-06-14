using UnityEngine;
using System.Collections;
using Assets.Scripts.Events;
using Assets.Scripts.Events.EventTypes;
using System.Collections.Generic;
using Assets.Scripts.UI;

namespace Assets.Scripts
{
    public class DialogTrigger : MonoBehaviour
    {
        [SerializeField]
        private EventManager mEventManager;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                mEventManager.PublishEvent(new StartDialogEvent(
                    new List<StartDialogEvent.DialogParams>
                    {
                        new StartDialogEvent.DialogParams(
                            "Bae Fox Girl",
                            "I want juice.",
                            PortraitId.FOX_GIRL),
                        new StartDialogEvent.DialogParams(
                            "Ya Girl The MC",
                            "Uh ok",
                            PortraitId.MC),
                        new StartDialogEvent.DialogParams(
                            "Bae Fox Girl",
                            "Go get me some juice",
                            PortraitId.FOX_GIRL),
                        new StartDialogEvent.DialogParams(
                            "Confused MC",
                            "Who even are you?",
                            PortraitId.MC),
                        new StartDialogEvent.DialogParams(
                            "Bae Fox Girl",
                            "Doesn't matter, just get me juice before I start screaming.",
                            PortraitId.FOX_GIRL),
                        new StartDialogEvent.DialogParams(
                            "MC",
                            "Wtf? Aren't you too old to be screaming for juice",
                            PortraitId.MC),
                        new StartDialogEvent.DialogParams(
                            "Screaming Fox Girl",
                            "JUICEEEEEEE!!!!!!!!!!!?????$@$%!",
                            PortraitId.FOX_GIRL),
                        new StartDialogEvent.DialogParams(
                            "Screaming Fox Girl",
                            "#@!^@#$^$#@!%@!@#$!",
                            PortraitId.FOX_GIRL),
                        new StartDialogEvent.DialogParams(
                            "Screaming Fox Girl",
                            "awfg24gqgqgb3w5y31#!$!#",
                            PortraitId.FOX_GIRL),
                        new StartDialogEvent.DialogParams(
                            "Screaming Fox Girl",
                            "JUICE",
                            PortraitId.FOX_GIRL),
                    }
                ));
            }
        }
    }
}