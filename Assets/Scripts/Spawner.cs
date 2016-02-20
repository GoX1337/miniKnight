using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject skeleton;
    public int enemyNumber;
    private float deltaTime;

	// Use this for initialization
	void Start () {
        this.enemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Initial enemy number : " + this.enemyNumber);
	}
	
	// Update is called once per frame
	void Update () {
        this.deltaTime += Time.deltaTime;

        // Check enemy number every 5s
        if (deltaTime >= 5)
        {
            // Spawn an enemy
            if (enemyNumber == 0)
            {
                Instantiate(skeleton);
                Debug.Log(skeleton.name + " respawned at : " + skeleton.transform.position);
                this.enemyNumber++;
            }
            deltaTime = 0;
        }
	}
}
