using UnityEngine;

public class OnHitPlayerTrigger : MonoBehaviour
{

    EnemyBaseController mEnemyBaseController;

    private void Awake()
    {
        mEnemyBaseController = GetComponentInParent<EnemyBaseController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            mEnemyBaseController.OnHitPlayer(collider.gameObject);
        }
    }
}
