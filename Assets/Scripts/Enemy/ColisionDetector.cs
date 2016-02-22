using UnityEngine;
using System.Collections;

public class ColisionDetector : MonoBehaviour {

	private EnemyAI enemyAI;

    void Start()
    {
        enemyAI = this.gameObject.GetComponentInParent<EnemyAI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "gounddirtcavern_0")
        {
			this.gameObject.GetComponentInParent<EnemyAI>().ChangePatrolDirection();
        }
        else if (other.name == "Knight")
        {
            enemyAI.Stop();
            enemyAI.Attack();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "gounddirtcavern_0")
        {
			this.gameObject.GetComponentInParent<EnemyAI>().ChangePatrolDirection();
        }
        else if (other.name == "Knight")
        {
            enemyAI.Stop();
            enemyAI.Attack();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "gounddirtcavern_0")
        {
			this.gameObject.GetComponentInParent<EnemyAI>().ChangePatrolDirection();
        }
        else if (other.name == "Knight")
        {
            enemyAI.RestartPatrol();
        }
    }
}
