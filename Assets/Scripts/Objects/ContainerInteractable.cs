using Assets.Scripts.Player;
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
        if (character is PlayerModel)
        {
            if (mIsOpened)
            {
                return;
            }

            ((PlayerModel) character).mInventory.AddItem(mContainedItem, mCount);
            mSpriteRenderer.sprite = mOpenedSprite;
            mIsOpened = true;
        }
    }
}