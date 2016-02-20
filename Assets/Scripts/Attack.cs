using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    private Animator playerAnimator;
    private float attackDelay;

	// Use this for initialization
	void Start () {
        playerAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl) && this.attackDelay >= 0.3){
            this.attackDelay = 0;
            this.playerAnimator.SetTrigger("attack");
        }
        this.attackDelay += Time.deltaTime;
	}
}
