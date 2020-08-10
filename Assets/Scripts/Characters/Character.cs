using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMovementModel mMovementModel;
    public CharacterInteractionModel mInteractionModel;
    public CharacterInventoryModel mInventory;

    void Awake()
    {
        mMovementModel = GetComponent<CharacterMovementModel>();
        mInteractionModel = GetComponent<CharacterInteractionModel>();
        mInventory = GetComponent<CharacterInventoryModel>();
    }

    public void SetCanMove(bool canMove)
    {
        mMovementModel.SetCanMove(canMove);
    }

    public void SetDestroyed()
    {
        SetCanMove(false);
    }
}
