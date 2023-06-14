using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
    public class PlayerMovementModel : CharacterMovementModel 
    {
        [SerializeField] private float mRunSpeed = 7f;
        private float mDashSpeed = 20f;
        private float mMaxDashTime = 0.4f;

        private bool mIsRunningEnabled;
        private bool mIsJumping;
        private bool mIsAttacking;
        private DashState mDashState;
        private float mDashTimer;
        private float mDashTimerIncrementSpeed = 3f;
        private float mDashTimerDecrementSpeed = 2f;

        void Awake() {
            mRigidbody = GetComponent<Rigidbody2D>();
            mRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            mCanMove = true;
            mIsAttacking = false;
        }

        void FixedUpdate() {
            UpdateDash();
            UpdateMovement();
            UpdateKnockbackTime();
        }

        void UpdateDash()
        {
            switch (mDashState)
            {
                case DashState.Dashing:
                    mDashTimer += Time.deltaTime * mDashTimerIncrementSpeed;
                    if (mDashTimer > mMaxDashTime)
                    {
                        mDashTimer = mMaxDashTime;
                        mDashState = DashState.Cooldown;
                    }
                    break;
                case DashState.Cooldown:
                    mDashTimer -= Time.deltaTime * mDashTimerDecrementSpeed;
                    if (mDashTimer < 0)
                    {
                        mDashTimer = 0;
                        mDashState = DashState.Ready;
                    }
                    break;
                case DashState.Ready:
                default:
                    break;
            }
        }

        protected override void UpdateMovement() {
            base.UpdateMovement();
            mMovementDirection.Normalize();

            if (IsKnockbacked())
            {
                mRigidbody.velocity = mKnockbackDirection;
            } else if (mDashState == DashState.Dashing)
            {
                mRigidbody.velocity = mCurrentDirection * mDashSpeed;
            } else
            {
                var speed = IsRunning() ? mRunSpeed : mDefaultSpeed;
                mRigidbody.velocity = mMovementDirection * speed;
            }
        }

        public void Dash()
        {
            if (mDashState == DashState.Ready && mMovementDirection != Vector3.zero)
            {
                mDashState = DashState.Dashing;
            }
        }

        public float GetRemainingDashDistance()
        {
            int remainingCycles = (int) ((mMaxDashTime - mDashTimer) / (Time.deltaTime * mDashTimerIncrementSpeed)) + 1;
            return remainingCycles * mDashSpeed;
        }

        public bool IsRunning()
        {
            return mIsRunningEnabled && IsMoving();
        }

        public bool IsDashing()
        {
            return mDashState == DashState.Dashing;
        }

        public void SetRunningEnabled(bool isRunningEnabled)
        {
            mIsRunningEnabled = isRunningEnabled;
        }

        public bool IsJumping()
        {
            return mIsJumping;
        }

        public void DoJump()
        {
            Debug.Log("Jumping");
        }

        public void OnJumpStarted()
        {
            SetCanMove(false);
            mIsJumping = true;
        }

        public void OnJumpFinished()
        {
            SetCanMove(true);
            mIsJumping = false;
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

        public void OnProjectileThrowEnd()
        {
            OnAttackFinished();
        }

        public void OnProjectileThrowStart()
        {
            OnAttackStarted();
        }

    }
}