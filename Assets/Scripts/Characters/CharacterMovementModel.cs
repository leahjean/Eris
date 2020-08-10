using UnityEngine;
using System.Collections;
using System;

/**
 * Model class for Main Character movement.
 */
public class CharacterMovementModel : MonoBehaviour {
    public float mSpeed;

    private Vector3 mMovementDirection;
    private Rigidbody2D mRigidbody;
    private Vector3 mCurrentDirection;
    private bool mCanMove;
    private bool mIsAttacking;
    private Vector2 mKnockbackDirection;
    private float mKnockbackTime;

    void Awake() {
        mRigidbody = GetComponent<Rigidbody2D>();
        mRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        mCanMove = true;
        mIsAttacking = false;
    }

    void FixedUpdate() {
        UpdateMovement();
        UpdateKnockbackTime();
    }

    void UpdateMovement() {
        mMovementDirection.Normalize();

        if (IsKnockbacked())
        {
            mRigidbody.velocity = mKnockbackDirection;
        } else
        {
            mRigidbody.velocity = mMovementDirection * mSpeed;
        }
    }

    void UpdateKnockbackTime()
    {
        if (IsKnockbacked())
        {
            mKnockbackTime = Mathf.MoveTowards(mKnockbackTime, 0f, Time.deltaTime);
        }
    }

    public void SetDirection(Vector2 direction) {
        if (!mCanMove) {
            mMovementDirection = Vector3.zero;
            return;
        }
        mMovementDirection = IsKnockbacked() ?
            new Vector3(mKnockbackDirection.x, mKnockbackDirection.y, 0) :
            new Vector3(direction.x, direction.y, 0);
        if (direction != Vector2.zero) {
            mCurrentDirection = mMovementDirection;
        }
    }

    public void SetCanMove(bool canMove) {
        mCanMove = canMove;
    }

    public Vector3 GetMovementDirection() {
        return mMovementDirection;
    }

    public Vector3 GetCurrentDirection() {
        return mCurrentDirection;
    }

    public bool IsMoving() {
        return mMovementDirection != Vector3.zero;
    }

    public void KnockBack(Vector2 direction, float time)
    {
        Debug.Log("KnockBack : " + direction + " " + time);
        mKnockbackDirection = direction;
        mKnockbackTime = time;
    }

    public bool IsKnockbacked()
    {
        return mKnockbackTime > 0;
    }

    public bool CanAttack()
    {
        return !IsAttacking();
    }

    public bool IsAttacking()
    {
        return mIsAttacking;
    }

    public void DoAttack()
    {
        Debug.Log("Attacking");
    }

    public void OnAttackStarted()
    {
        SetCanMove(false);
        mIsAttacking = true;
    }

    public void OnAttackFinished()
    {
        SetCanMove(true);
        mIsAttacking = false;
    }
}
