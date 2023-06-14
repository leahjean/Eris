using UnityEngine;

public class BushAttackable : BaseAttackable
{

    public Sprite mDestroyedSprite;
    public GameObject DestroyEffect;

    private SpriteRenderer mSpriteRenderer;
    void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnHit(Character attacker)
    {
        Debug.Log("Bush getting hit");
        mSpriteRenderer.sprite = mDestroyedSprite;
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        if (DestroyEffect != null)
        {
            GameObject destroyEffect = Instantiate(DestroyEffect);
            destroyEffect.transform.position = transform.position;
        }
    }
}
