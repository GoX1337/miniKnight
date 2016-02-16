using UnityEngine;
using System.Collections;

public class ColisionDetector : MonoBehaviour {

    private AI ai;

    void Start()
    {
        ai = this.gameObject.GetComponentInParent<AI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "gounddirtcavern_0")
        {
            this.gameObject.GetComponentInParent<AI>().ChangePatrolDirection();
        }
        else if (other.name == "Knight")
        {
            ai.Stop();
            ai.Attack();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "gounddirtcavern_0")
        {
            this.gameObject.GetComponentInParent<AI>().ChangePatrolDirection();
        }
        else if (other.name == "Knight")
        {
            ai.Stop();
            ai.Attack();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "gounddirtcavern_0")
        {
            this.gameObject.GetComponentInParent<AI>().ChangePatrolDirection();
        }
        else if (other.name == "Knight")
        {
            ai.RestartPatrol();
        }
    }
}
