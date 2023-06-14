using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Tilemap mTileMap;
        private Character mCharacter;
        private float mMinX;
        private float mMaxX;
        private float mMinY;
        private float mMaxY;

        // Use this for initialization
        void Start()
        {
            mCharacter = GetComponentInParent<Character>();
            Vector3 bounds = mTileMap.localBounds.size;
            Debug.Log(bounds);
            Debug.Log(mTileMap.cellSize);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}