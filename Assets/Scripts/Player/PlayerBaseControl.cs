using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerModel))]
    [RequireComponent(typeof(PlayerMovementModel))]
    public class PlayerBaseControl : CharacterBaseControl 
    {
        protected void SetRunningEnabled(bool isRunningEnabled)
        {
            GetPlayerModel().GetPlayerMovementModel().SetRunningEnabled(isRunningEnabled);
        }

        protected void OnJumpPressed()
        {
            GetPlayerModel().GetPlayerMovementModel().DoJump();
            GetPlayerMovementView().DoJump();
        }

        protected void OnAttackPressed()
        {
            GetPlayerModel().GetPlayerMovementModel().DoAttack();
            GetPlayerMovementView().DoAttack();
        }

        protected void OnProjectileThrown()
        {
            GetPlayerMovementView().ThrowProjectile();
        }

        protected void Interact()
        {
            Vector3 currentDirection = GetPlayerModel().GetPlayerMovementModel().GetCurrentDirection();
            GetPlayerModel().mInteractionModel.OnInteract(currentDirection, GetPlayerModel());
        }

        protected void Escape()
        {
            GetPlayerModel().mInteractionModel.OnEscape(GetPlayerModel());
        }

        protected void Dash()
        {
            GetPlayerModel().GetPlayerMovementModel().Dash();
        }

        public PlayerModel GetPlayerModel()
        {
            return (PlayerModel) mCharacterModel;
        }

        public PlayerMovementView GetPlayerMovementView()
        {
            return (PlayerMovementView) mCharacterMovementView;
        }

        public void OnAttacked(AttackParams attackParams)
        {
            GetPlayerModel().OnAttacked(attackParams);
        }
    }
}