using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    private static readonly string DEFAULT_TEXT = "...";

    private Image mImage;
    private Text mText;
    private static DialogBox sInstance;

    void Awake() {
        mImage = GetComponent<Image>();
        mText = GetComponentInChildren<Text>();
        sInstance = this;
        Debug.Log(mImage);
        Debug.Log(mText);
        Hide();
    }

    public static void Show(string newText) {
        GetInstance().mImage.enabled = true;
        GetInstance().mText.enabled = true;
        ChangeText(newText);
    }

    public static void Hide() {
        GetInstance().mImage.enabled = false;
        GetInstance().mText.enabled = false;
        ResetText();
    }

    public static void ChangeText(string newText) {
        GetInstance().mText.text = newText;
    }

    public static bool IsVisible() {
        return GetInstance().mImage.enabled;
    }

    private static void ResetText() {
        ChangeText(DEFAULT_TEXT);
    }

    private static DialogBox GetInstance() {
        return sInstance;
    }
}