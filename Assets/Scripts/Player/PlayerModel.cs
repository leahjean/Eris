using UnityEngine;

namespace Assets.Scripts.Player
{
    /**
     * Player version of Character with extra utilities for modeling unique to players.
     */
    [RequireComponent(typeof(PlayerInteractionModel))]
    [RequireComponent(typeof(PlayerInventoryModel))]
    [RequireComponent(typeof(PlayerMovementModel))]
    public class PlayerModel : Character
    {
        [SerializeField] public PlayerInteractionModel mInteractionModel;
        [SerializeField] public PlayerInventoryModel mInventory;
        public PlayerStatus mPlayerStatus { get; private set;}

        protected void Awake()
        {
            mPlayerStatus = new PlayerStatus(10f);
        }

        public PlayerMovementModel GetPlayerMovementModel()
        {
            return (PlayerMovementModel) mMovementModel;
        }

        public void OnAttacked(AttackParams attackParams)
        {
            // Trigger knockback
            Vector2 direction = transform.position - attackParams.mAttackerTransform.position;
            direction.Normalize();
            GetPlayerMovementModel().KnockBack(direction * attackParams.mKnockbackStrength,
                attackParams.mKnockbackTime);

            // Trigger Health Drop
            mPlayerStatus.mHealth -= attackParams.mBaseDamage * mPlayerStatus.mDefenseMultiplier
                - mPlayerStatus.mDefenseFlatValue;
            Debug.Log(mPlayerStatus.mHealth);
        }
    }
}