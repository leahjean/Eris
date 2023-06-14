using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{

    public class ProjectileController : MonoBehaviour
    {
        private Character mCharacter;
        private float mStartOffset = 0.5f;
        private float mSpeed = 15f;
        private float mLifeTime = 1.5f;

        public void Init(Character character)
        {
            mCharacter = character;
            GetComponent<Renderer>().enabled = true;
            Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();

            // Init initial position based on character position
            Vector3 position = mCharacter.transform.position;
            Vector3 direction = Vector3.Normalize(mCharacter.mMovementModel.GetCurrentDirection());

            float x = position.x + mStartOffset * direction.x;
            float y = position.y + mStartOffset * direction.y;
            transform.position = new Vector2(x, y);

            rigidBody2D.velocity = new Vector2(direction.x * mSpeed, direction.y * mSpeed);
            Destroy(this.gameObject, mLifeTime);
        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("Hit");
            BaseAttackable attackable = collider.gameObject.GetComponent<BaseAttackable>();
            if (attackable != null)
            {
                Debug.Log("Attacking: " + attackable);
                attackable.OnHit(mCharacter);
                Destroy(this.gameObject);
            } else
            { 
                Debug.Log("Hit enemy is null: " + collider.gameObject);
            }
        }
    }


}