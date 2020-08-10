using UnityEngine;

public abstract class BaseAttackable : MonoBehaviour
{
    public abstract void OnHit(Character attacker);
    public virtual void OnDestroy() { }
}