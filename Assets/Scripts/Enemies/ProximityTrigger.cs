using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{

    EnemyBaseController mEnemyBaseController;

    void Start()
    {
        mEnemyBaseController = GetComponentInParent<EnemyBaseController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Okay");
            mEnemyBaseController.SetCharacterInRange(collider.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            mEnemyBaseController.SetCharacterInRange(null);
        }
    }
}
