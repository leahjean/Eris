using Assets.Scripts.Player;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMovementView : MonoBehaviour
{
    public Animator mAnimator;

    protected Character mCharacter;

    protected void Awake()
    {
        mCharacter = GetComponent<Character>();
    }

    protected void FixedUpdate()
    {
        UpdateDirection();
        UpdateKnockback();
    }

    protected virtual void UpdateDirection()
    {
        Vector3 direction = mCharacter.mMovementModel.GetMovementDirection();
        if (direction != Vector3.zero)
        {
            mAnimator.SetFloat( "directionX", direction.x );
            mAnimator.SetFloat( "directionY", direction.y );
        }

        mAnimator.SetBool("isMoving", mCharacter.mMovementModel.IsMoving());
    }

    void UpdateKnockback()
    {
        mAnimator.SetBool("isKnockbacked", mCharacter.mMovementModel.IsKnockbacked());
    }


    // Todo: Make this only for enemies
    public void OnDestroy()
    {
        mAnimator.SetTrigger("onDestroy");
    }
}
