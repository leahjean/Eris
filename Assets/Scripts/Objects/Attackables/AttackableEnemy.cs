using UnityEngine;

[RequireComponent(typeof(EnemyBaseController))]
public class AttackableEnemy : BaseAttackable
{
    public float mMaxHealth;

    private float mCurrentHealth;
    private EnemyBaseController controller;

    void Start()
    {
        controller = GetComponent<EnemyBaseController>();
    }

    void Awake()
    {
        mCurrentHealth = mMaxHealth;
    }

    // Update is called once per frame
    public override void OnHit(Character attacker)
    {
        mCurrentHealth--;
        Debug.Log("Current Health: " + mCurrentHealth);
        controller.OnGetHit(attacker);
        if (mCurrentHealth <= 0)
        {
            OnDestroy();
        }
    }

    public override void OnDestroy()
    {
        controller.OnDestroy();
        Debug.Log("Destroyed object");
    }
}
