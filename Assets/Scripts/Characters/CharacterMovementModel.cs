using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Player;

/**
 * Model class for Main Character movement.
 */
public class CharacterMovementModel : MonoBehaviour {
    [SerializeField] protected float mDefaultSpeed = 4f;

    protected Vector3 mMovementDirection;
    protected Rigidbody2D mRigidbody;
    protected Vector3 mCurrentDirection;
    protected bool mCanMove;
    protected Vector2 mKnockbackDirection;
    protected float mKnockbackTime;

    void Awake() {
        mRigidbody = GetComponent<Rigidbody2D>();
        mRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        mCanMove = true;
    }

    void FixedUpdate() {
        UpdateMovement();
        UpdateKnockbackTime();
    }

    protected virtual void UpdateMovement() {
        mMovementDirection.Normalize();

        if (IsKnockbacked())
        {
            mRigidbody.velocity = mKnockbackDirection;
        } else
        {
            mRigidbody.velocity = mMovementDirection * mDefaultSpeed;
        }
    }

    protected void UpdateKnockbackTime()
    {
        if (IsKnockbacked())
        {
            mKnockbackTime = Mathf.MoveTowards(mKnockbackTime, 0f, Time.deltaTime);
        }
    }

    public void SetDirection(Vector2 direction)
    {
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

    public bool CanMove()
    {
        return mCanMove;
    }

    public void SetCanMove(bool canMove) 
    {
        mCanMove = canMove;
    }

    public Vector3 GetMovementDirection()
    {
        return mMovementDirection;
    }

    public Vector3 GetCurrentDirection()
    {
        return mCurrentDirection;
    }

    public bool IsMoving()
    {
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
}
