using UnityEngine;
using System.Collections;

public class GroundSensor : MonoBehaviour {

    private PlayerMove move;

	// Use this for initialization
	void Start () {
		move = GetComponentInParent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        move.grounded = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        move.grounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        move.grounded = false;
    }
}
