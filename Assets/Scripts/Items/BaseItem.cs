using UnityEngine;

public class BaseItem : MonoBehaviour
{
    private readonly ItemIdentifier mIdentifier;

    protected BaseItem(ItemIdentifier identifier)
    {
        mIdentifier = identifier;
    }

    public virtual string GetName() {
        return this.GetType().Name;
    }

    public ItemIdentifier GetIdentifier()
    {
        return mIdentifier;
    }
}
