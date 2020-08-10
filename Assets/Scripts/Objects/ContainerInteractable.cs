using UnityEngine;

/**
 * Single-use containers that can open
 */
public class ContainerInteractable : BaseInteractable
{

    public BaseItem mContainedItem;
    public Sprite mOpenedSprite;
    public int mCount;

    private SpriteRenderer mSpriteRenderer;
    private bool mIsOpened;

    protected virtual void Start()
    {
        mSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void OnInteract(Character character)
    {
        if (mIsOpened)
        {
            return;
        }

        character.mInventory.AddItem(mContainedItem, mCount);
        mSpriteRenderer.sprite = mOpenedSprite;
        mIsOpened = true;
    }
}