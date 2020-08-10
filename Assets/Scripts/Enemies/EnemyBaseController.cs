using UnityEngine;

public class EnemyBaseController : CharacterBaseControl
{
    public float mKnockbackStrength;
    public float mKnockbackTime;

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

    public void OnHitPlayer(GameObject player)
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        player.GetComponent<Character>()
            .mMovementModel
            .KnockBack(direction * mKnockbackStrength, mKnockbackTime);
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
