using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject mUI;

        private static bool IsGamePaused;
        private PauseMenuButton[] mButtons;
        private int mSelectedButtonIndex;

        private void Start()
        {
            mUI.SetActive(true);
            mButtons = this.GetComponentsInChildren<PauseMenuButton>();
            foreach(PauseMenuButton button in mButtons) {
                button.OnFocusExit();
            }
            Resume();
        }

        void Update()
        {
            if (IsGamePaused)
            {
                UpdateButtonVisibility(mSelectedButtonIndex, true);
                if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
                {
                    Resume();
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SelectButton(MathUtils.Mod(mSelectedButtonIndex + 1, mButtons.Length));
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SelectButton(MathUtils.Mod(mSelectedButtonIndex - 1, mButtons.Length));
                }
            } else
            {
                if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
            }
        }

        private void Pause()
        {
            mUI.SetActive(true);
            IsGamePaused = true;
            UpdateButtonVisibility(0, true);
            mSelectedButtonIndex = 0;
            Time.timeScale = 0f;
        }

        private void Resume()
        {
            mUI.SetActive(false);
            IsGamePaused = false;
            Time.timeScale = 1f;
            UpdateButtonVisibility(mSelectedButtonIndex, false);
        }

        private void SelectButton(int newButtonIndex)
        {
            UpdateButtonVisibility(mSelectedButtonIndex, false);
            UpdateButtonVisibility(newButtonIndex, true);
            mSelectedButtonIndex = newButtonIndex;
        }

        private void UpdateButtonVisibility(int buttonIndex, bool isEnabled)
        {
            PauseMenuButton button = mButtons[buttonIndex];
            if (button.IsFocused() != isEnabled) {
                if (isEnabled)
                {
                    button.OnFocusEnter();
                } else
                {
                    button.OnFocusExit();
                }
            }
        }
    }
}