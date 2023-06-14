using Assets.Scripts.Enemies;
using Assets.Scripts.UI;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public CharacterMovementModel mMovementModel;
   

    public void SetCanMove(bool canMove)
    {
        mMovementModel.SetCanMove(canMove);
    }

    public void SetDestroyed()
    {
        SetCanMove(false);
    }

    /*
    public void OnGetHit(Enemy attackingEnemy)
    {
        Vector2 direction = this.transform.position - attackingEnemy.transform.position;
        direction.Normalize();

        mMovementModel.KnockBack(direction * amKnockbackStrength, mKnockbackTime);
    }
    */
}
