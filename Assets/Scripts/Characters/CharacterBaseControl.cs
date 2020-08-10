using UnityEngine;

public class CharacterBaseControl : MonoBehaviour {
    protected Character mCharacterModel;
    protected CharacterMovementView mCharacterMovementView;

    void Awake() {
        mCharacterModel = GetComponent<Character>();
        mCharacterMovementView = GetComponent<CharacterMovementView>();
    }

    protected void OnAttackPressed() {
        mCharacterModel.mMovementModel.DoAttack();
        mCharacterMovementView.DoAttack();
    }

    protected void Interact() {
        Vector3 currentDirection = mCharacterModel.mMovementModel.GetCurrentDirection();
    	mCharacterModel.mInteractionModel.OnInteract(currentDirection, mCharacterModel);
    }

    protected void Escape() {
        mCharacterModel.mInteractionModel.OnEscape(mCharacterModel);
    }

    protected void SetDirection(Vector2 direction) {
        if (mCharacterModel.mMovementModel == null) {
            Debug.LogError("No movement Model");
        }
        mCharacterModel.mMovementModel.SetDirection(direction);
    }
}
