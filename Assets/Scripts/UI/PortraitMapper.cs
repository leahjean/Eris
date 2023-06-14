using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public class PortraitMapper : MonoBehaviour
    {

        public Dictionary<PortraitId, Sprite> mPortraitIdToSpriteMap { get; private set; }
        // Use this for initialization
        void Start()
        {
            mPortraitIdToSpriteMap = new Dictionary<PortraitId, Sprite>
            {
                { PortraitId.FOX_GIRL, Resources.LoadAll<Sprite>("Portraits/FOX_GIRL")[0] },
                { PortraitId.MC, Resources.Load<Sprite>("Portraits/MC") },
            };
        }
    }
}