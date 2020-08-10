using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{
    public Animator mAnimator;
    public UnityEngine.Transform mWeapon;

    private CharacterMovementModel mMovementModel;

    void Awake()
    {
        mMovementModel = GetComponent<CharacterMovementModel>();

        if (mAnimator == null)
        {
            Debug.LogError("Character Animator is not setup!");
            enabled = false;
        }

        SetWeaponVisibility(false);
    }

    void FixedUpdate()
    {
        UpdateDirection();
        UpdateKnockback();
    }

    void UpdateDirection()
    {
        if (mMovementModel.IsAttacking())
        {
            mAnimator.SetBool("isMoving", false);
            return;
        }

        Vector3 direction = mMovementModel.GetMovementDirection();
        if (direction != Vector3.zero)
        {
            mAnimator.SetFloat( "directionX", direction.x );
            mAnimator.SetFloat( "directionY", direction.y );
        }

        mAnimator.SetBool("isMoving", mMovementModel.IsMoving());
    }

    void UpdateKnockback()
    {
        mAnimator.SetBool("isKnockbacked", mMovementModel.IsKnockbacked());
    }

    public void DoAttack()
    {
        if (mMovementModel.CanAttack())
        {
            mAnimator.SetTrigger("doAttack");
        }
    }

    public void OnAttackStarted()
    {
        SetWeaponVisibility(true);
    }

    public void OnAttackFinished()
    {
        SetWeaponVisibility(false);
    }

    private void SetWeaponVisibility(bool visible)
    {
        if (mWeapon == null)
        {
            return;
        }
        for (int i = 0; i < mWeapon.childCount; i++)
        {
            mWeapon.GetChild(i).gameObject.SetActive(visible);
        }
    }

    // Todo: Make this only for enemies
    public void OnDestroy()
    {
        mAnimator.SetTrigger("onDestroy");
    }
}
