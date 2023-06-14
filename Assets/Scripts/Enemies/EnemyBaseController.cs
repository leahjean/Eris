using Assets.Scripts.Player;
using UnityEngine;

public class EnemyBaseController : CharacterBaseControl
{
    public float mKnockbackStrength;
    public float mKnockbackTime;
    public float mBaseDamage;

    GameObject mCharacterInRange;

    void Update()
    {
        UpdateDirection();
    }

    void UpdateDirection()
    {
        Vector2 direction = Vector2.zero;

        if (mCharacterInRange != null)
        {
            direction = mCharacterInRange.transform.position - transform.position;
            direction.Normalize();
        }
        SetDirection(direction);
    }

    public void SetCharacterInRange(GameObject characterInRange)
    {
        mCharacterInRange = characterInRange;
    }

    public void OnHitPlayer(PlayerBaseControl playerBaseControl)
    {
        AttackParams attackParams = AttackParams.Builder()
            .KnockbackStrength(mKnockbackStrength)
            .KnockbackTime(mKnockbackTime)
            .BaseDamage(mBaseDamage)
            .AttackerTransform(transform)
            .Build();
        playerBaseControl.OnAttacked(attackParams);
    }

    public void OnGetHit(Character player)
    {
        Vector2 direction = transform.position - player.transform.position;
        direction.Normalize();

        mCharacterModel.mMovementModel.KnockBack(direction * 10, 0.2f);
    }

    // Todo: Make enemy only
    public void OnDestroy()
    {
        mCharacterModel.SetDestroyed();
        mCharacterMovementView.OnDestroy();
    }
}
