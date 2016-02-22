using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject skeleton;
    public int enemyNumber;
    public float deltaTime;
    public bool startTimerTrigger = false;

	// Use this for initialization
	void Start () {
        this.enemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Initial enemy number : " + this.enemyNumber);
	}
	
	// Update is called once per frame
	void Update () {

        if(this.startTimerTrigger)
        {
             this.deltaTime += Time.deltaTime;
        }
        
        // Check enemy number every 5s
        if (deltaTime >= 3)
        {
            // Spawn an enemy
            if (enemyNumber == 0)
            {
                Instantiate(skeleton);
                Debug.Log(skeleton.name + " respawned at : " + skeleton.transform.position);
                this.enemyNumber++;
                this.startTimerTrigger = false;
                deltaTime = 0;
            }
            
        }
	}

    public void EnemyDead(){
        this.startTimerTrigger = true;
        this.enemyNumber = 0;
    }
}
