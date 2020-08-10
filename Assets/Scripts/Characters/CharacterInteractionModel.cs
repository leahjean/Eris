using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Character))]
public class CharacterInteractionModel : MonoBehaviour {

    private BaseInteractable mFocusedInteractable;

    void Awake() {
        
    }

    void Update() {
    }

    public void OnInteract(Vector3 currentDirection, Character  character) {
        Vector3 currPosition = transform.position;
        Vector3 rayPosition = new Vector3(currPosition.x, currPosition.y - 0.2f, currPosition.z);
        RaycastHit2D[] hitObjects = Physics2D.RaycastAll(rayPosition, currentDirection, 1f);
        foreach (RaycastHit2D hitObject in hitObjects) {
            GameObject hitGameObject = hitObject.collider.gameObject;
            if (hitGameObject != this.gameObject) {
                Debug.Log("Interacting: " + hitGameObject.name);
                mFocusedInteractable = hitGameObject.GetComponent<BaseInteractable>();
                if (mFocusedInteractable != null) {
                    mFocusedInteractable.OnInteract(character);
                }
                break;
            }
        }
    }

    public void OnEscape(Character  character) {
        if (mFocusedInteractable != null) {
            mFocusedInteractable.OnEscape(character);
        }
    }
}
