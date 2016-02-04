using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 skelPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 rayOrig = new Vector2(transform.position.x - 0.2f, transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(rayOrig, Vector2.left);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "knightSprite_1")
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                
            }
        }
    }
}
