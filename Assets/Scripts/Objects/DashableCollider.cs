using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;

namespace Assets.Scripts.Objects
{
    /**
     * Attach to collider to allow players to dash through the collider
     */
    public class DashableCollider : MonoBehaviour
    {
        private Collider2D mCollider;

        private void Awake()
        {
            mCollider = GetComponent<Collider2D>();
            mCollider.isTrigger = true;
        }

        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Reached");
                Character character = collision.gameObject.GetComponent<Character>();
                float remainingDashDistance = character.mMovementModel.GetRemainingDashDistance();
                if (remainingDashDistance < mCollider.bounds.size.x)
                {
                    mCollider.isTrigger = true;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            mCollider.isTrigger = false;
        }
        */

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Reached");
                PlayerModel player = collision.gameObject.GetComponent<PlayerModel>();
                float remainingDashDistance = player.GetPlayerMovementModel().GetRemainingDashDistance();
                Debug.Log(remainingDashDistance);
                Debug.Log(mCollider.bounds.size.x);
                if (remainingDashDistance < mCollider.bounds.size.x)
                {
                    List<ContactPoint2D> contactPoints = new List<ContactPoint2D>();
                    collision.GetContacts(contactPoints);
                    Vector3 knockbackDirection = new Vector3(contactPoints[0].point.x - mCollider.bounds.center.x,
                        contactPoints[0].point.y - mCollider.bounds.center.y);
                    player.mMovementModel.KnockBack(knockbackDirection, 2);
                }
            }
           
        }
    }
}