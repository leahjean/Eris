using System.Collections;
using UnityEngine;

/**
 * Provide metadata about the attack to calculate behavior.
 */
public class AttackParams
{
    public float mKnockbackStrength { get; private set; }
    public float mKnockbackTime { get; private set; }
    public float mBaseDamage { get; private set; }
    public UnityEngine.Transform mAttackerTransform { get; private set; }

    public AttackParams(float knockbackStrength, float knockbackTime,
        float baseDamage, UnityEngine.Transform attackerTransform)
    {
        mKnockbackStrength = knockbackStrength;
        mKnockbackTime = knockbackTime;
        mBaseDamage = baseDamage;
        mAttackerTransform = attackerTransform;
    }

    public static AttackParamsBuilder Builder()
    {
        return new AttackParamsBuilder();
    }

    public class AttackParamsBuilder
    {
        private float mKnockbackStrength;
        private float mKnockbackTime;
        private float mBaseDamage;
        private UnityEngine.Transform mAttackerTransform;

        public AttackParamsBuilder KnockbackStrength(float knockbackStrength)
        {
            mKnockbackStrength = knockbackStrength;
            return this;
        }

        public AttackParamsBuilder KnockbackTime(float knockbackTime)
        {
            mKnockbackTime = knockbackTime;
            return this;
        }

        public AttackParamsBuilder BaseDamage(float baseDamage)
        {
            mBaseDamage = baseDamage;
            return this;
        }

        public AttackParamsBuilder AttackerTransform(UnityEngine.Transform attackerTransform)
        {
            mAttackerTransform = attackerTransform;
            return this;
        }

        public AttackParams Build()
        {
            return new AttackParams(mKnockbackStrength, mKnockbackTime, mBaseDamage, mAttackerTransform);
        }
    }
}