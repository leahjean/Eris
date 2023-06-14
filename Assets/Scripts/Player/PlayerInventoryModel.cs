using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerInventoryModel : MonoBehaviour
{
    Dictionary<BaseItem, int> mItemsAndCount;
    Dictionary<ItemIdentifier, List<BaseItem>> mItemsByType; 

    // Use this for initialization
    void Start()
    {
        mItemsAndCount = new Dictionary<BaseItem, int>();
        mItemsByType = new Dictionary<ItemIdentifier, List<BaseItem>>();
    }

    public void AddItem(BaseItem item)
    {
        AddItem(item, 1);
    }

    public void AddItem(BaseItem item, int count) {
        mItemsAndCount.TryGetValue(item, out var currentCount);
        mItemsAndCount[item] = currentCount + 1;

        if (!mItemsByType.ContainsKey(item.GetIdentifier()))
        {
            mItemsByType.Add(item.GetIdentifier(), new List<BaseItem>());
        }
        mItemsByType[item.GetIdentifier()].AddRange(Enumerable.Repeat(item, count));

        Debug.Log("Adding " + count + " of item: " + item.GetName());
    }
}
