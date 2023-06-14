using UnityEngine;
using System.Collections;
using Assets.Scripts.UI;

namespace Assets.Scripts.Player
{
    public class PlayerMovementView : CharacterMovementView 
    {
        [SerializeField] UnityEngine.Transform mWeapon = null;
        [SerializeField] UnityEngine.Transform mProjectileEffect = null;
        [SerializeField] GameObject mProjectile;
        private HealthBar mHealthBar;

        public PlayerModel GetPlayerModel()
        {
            return (PlayerModel) mCharacter;
        }

        protected new void Awake()
        {
            base.Awake();
            GameObject[] huds = GameObject.FindGameObjectsWithTag("HUD");
            if (huds.Length == 0)
            {
                throw new System.ArgumentException();
            }
            GameObject hud = huds[0];
            mHealthBar = hud.GetComponentInChildren<HealthBar>();
        }

        protected new void FixedUpdate()
        {
            base.FixedUpdate();
            UpdateHealthBar();
        }

        protected override void UpdateDirection()
        {
            if (GetPlayerModel().GetPlayerMovementModel().IsAttacking() || GetPlayerModel().GetPlayerMovementModel().IsJumping())
            {
                mAnimator.SetBool("isMoving", false);
                return;
            }

            Vector3 direction = GetPlayerModel().GetPlayerMovementModel().GetMovementDirection();
            if (direction != Vector3.zero)
            {
                mAnimator.SetFloat("directionX", direction.x);
                mAnimator.SetFloat("directionY", direction.y);
            }

            mAnimator.SetBool("isMoving", GetPlayerModel().GetPlayerMovementModel().IsMoving());
            mAnimator.SetBool("isRunning", GetPlayerModel().GetPlayerMovementModel().IsRunning());
            mAnimator.SetBool("isDashing", GetPlayerModel().GetPlayerMovementModel().IsDashing());
        }

        void UpdateHealthBar()
        {
            mHealthBar.SetMaxHealth(GetPlayerModel().mPlayerStatus.mMaxHealth);
            mHealthBar.SetHealth(GetPlayerModel().mPlayerStatus.mHealth);
        }

        public void DoJump()
        {
            if (GetPlayerModel().GetPlayerMovementModel().CanMove())
            {
                mAnimator.SetTrigger("doJump");
            }
        }

        public void DoAttack()
        {
            if (GetPlayerModel().GetPlayerMovementModel().CanAttack())
            {
                mAnimator.SetTrigger("doAttack");
            }
        }

        public void OnAttackStarted()
        {
            SetAttackVisibility(mWeapon, true);
        }

        public void OnAttackFinished()
        {
            SetAttackVisibility(mWeapon, false);
        }

        public void ThrowProjectile()
        {
            if (GetPlayerModel().GetPlayerMovementModel().CanAttack())
            {
                mAnimator.SetTrigger("throwProjectile");
                GameObject projectile = Instantiate(mProjectile);
                projectile.GetComponent<ProjectileController>().Init(GetComponent<Character>());
            }
        }

        public void OnProjectileThrowStart()
        {
            SetAttackVisibility(mProjectileEffect, true);
        }

        public void OnProjectileThrowEnd()
        {
            SetAttackVisibility(mProjectileEffect, false);
        }

        private void SetAttackVisibility(UnityEngine.Transform attackObject, bool isVisible)
        {
            if (attackObject == null)
            {
                return;
            }
            for (int i = 0; i < attackObject.childCount; i++)
            {
                attackObject.GetChild(i).gameObject.SetActive(isVisible);
            }
        }
    }
}