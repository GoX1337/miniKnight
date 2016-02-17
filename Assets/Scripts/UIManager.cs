using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas menu;

	// Use this for initialization
	void Start () {
        menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.enabled)
            {
                menu.enabled = false;
                Time.timeScale = 1.0f;
            }
            else
            {
                menu.enabled = true;
                Time.timeScale = 0f;
            }
        }
	}

    public void Resume()
    {
        Debug.Log("Resume");
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}
