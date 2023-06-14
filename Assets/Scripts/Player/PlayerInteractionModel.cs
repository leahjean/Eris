using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;

[RequireComponent(typeof(Character))]
public class PlayerInteractionModel : MonoBehaviour {

    private BaseInteractable mFocusedInteractable;

    void Awake() {
        
    }

    void Update() {
    }

    public void OnInteract(Vector3 currentDirection, PlayerModel player) {
        Vector3 currPosition = transform.position;
        Vector3 rayPosition = new Vector3(currPosition.x, currPosition.y - 0.2f, currPosition.z);
        RaycastHit2D[] hitObjects = Physics2D.RaycastAll(rayPosition, currentDirection, 1f);
        foreach (RaycastHit2D hitObject in hitObjects) {
            GameObject hitGameObject = hitObject.collider.gameObject;
            if (hitGameObject != this.gameObject) {
                Debug.Log("Interacting: " + hitGameObject.name);
                mFocusedInteractable = hitGameObject.GetComponent<BaseInteractable>();
                if (mFocusedInteractable != null) {
                    mFocusedInteractable.OnInteract(player);
                }
                break;
            }
        }
    }

    public void OnEscape(PlayerModel player) {
        if (mFocusedInteractable != null) {
            mFocusedInteractable.OnEscape(player);
        }
    }
}
