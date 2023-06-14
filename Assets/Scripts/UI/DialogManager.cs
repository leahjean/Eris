using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.Events.EventTypes;
using Assets.Scripts.Events;

namespace Assets.Scripts.UI
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField]
        private EventManager mEventManager;
        [SerializeField]
        private Text mSpeaker;
        [SerializeField]
        private Text mDialogText;
        [SerializeField]
        private Image mPortraitImage;

        private PortraitMapper mPortraitMapper;
        private List<StartDialogEvent.DialogParams> mDialog;
        private int mCurrentDisplayIndex;

        private void Start()
        {
            mPortraitMapper = this.gameObject.AddComponent<PortraitMapper>();
            SetIsUIVisible(false);
        }

        void Update()
        {
            if (IsDialogActive())
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    NextDialog();
                }
            }
        }

        public void InitDialog(string fileName)
        {

        }

        public void InitDialog(List<StartDialogEvent.DialogParams> dialog) 
        {
            SetIsUIVisible(true);
            mDialog = dialog;
            mCurrentDisplayIndex = 0;
            UpdateCurrentDialog();
        }

        public void EndDialog()
        {
            SetIsUIVisible(false);
            mDialog = null;
            mCurrentDisplayIndex = 0;
            mEventManager.PublishEvent(new EndDialogEvent());
        }

        public bool IsDialogActive()
        {
            return mDialog != null;
        }

        private void NextDialog()
        {
            if (++mCurrentDisplayIndex >= mDialog.Count)
            {
                EndDialog();
            } else
            {
                UpdateCurrentDialog();
            }
        }

        private void UpdateCurrentDialog()
        {
            StartDialogEvent.DialogParams dialogParams = mDialog[mCurrentDisplayIndex];
            mSpeaker.text = dialogParams.mSpeakerName;
            mPortraitImage.sprite = mPortraitMapper.mPortraitIdToSpriteMap[dialogParams.mPortraitSpriteId];
            Debug.Log(mPortraitImage.sprite);
            mDialogText.text = dialogParams.mDialogText;
        }

        private void SetIsUIVisible(bool isVisible)
        {
            foreach (UnityEngine.Transform transform in this.transform)
            {
                transform.gameObject.SetActive(isVisible);
            }
        }


    }
}