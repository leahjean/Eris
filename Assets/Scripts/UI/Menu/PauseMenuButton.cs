using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu
{
    public class PauseMenuButton : MonoBehaviour
    {
        [SerializeField]
        private Image mFocusedIndicator;
        // Use this for initialization
        void Start()
        {
            mFocusedIndicator.enabled = false;
        }

        public void OnFocusEnter()
        {
            mFocusedIndicator.enabled = true;
        }

        public void OnFocusExit()
        {
            mFocusedIndicator.enabled = false;
        }

        public bool IsFocused()
        {
            return mFocusedIndicator.enabled;
        }
    }
}