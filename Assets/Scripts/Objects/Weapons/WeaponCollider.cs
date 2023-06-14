using UnityEngine;

public class WeaponCollider : MonoBehaviour
{

    public Character mCharacter;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit");
        BaseAttackable attackable = collider.gameObject.GetComponent<BaseAttackable>();
        if (attackable != null)
        {
            Debug.Log("Attacking: " + attackable);
            attackable.OnHit(mCharacter);
        }
    }
}
