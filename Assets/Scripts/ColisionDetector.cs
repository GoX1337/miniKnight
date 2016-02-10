using UnityEngine;
using System.Collections;

public class ColisionDetector : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "gounddirtcavern_0")
        {
            this.gameObject.GetComponentInParent<AI>().ChangePatrolDirection();
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.name == "gounddirtcavern_0")
        {
            this.gameObject.GetComponentInParent<AI>().ChangePatrolDirection();
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.name == "gounddirtcavern_0")
        {
            this.gameObject.GetComponentInParent<AI>().ChangePatrolDirection();
        }
    }
}
