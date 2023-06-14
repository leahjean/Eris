using Assets.Scripts.Enemies;
using UnityEngine;

public class CharacterBaseControl : MonoBehaviour {
    protected Character mCharacterModel;
    protected CharacterMovementView mCharacterMovementView;

    void Awake() {
        mCharacterModel = GetComponent<Character>();
        mCharacterMovementView = GetComponent<CharacterMovementView>();
    }

    protected void SetDirection(Vector2 direction) {
        mCharacterModel.mMovementModel.SetDirection(direction);
    }

    public void SetCanMove(bool canMove)
    {
        mCharacterModel.SetCanMove(canMove);
    }
}
