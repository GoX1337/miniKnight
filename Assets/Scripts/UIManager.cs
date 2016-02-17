using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas menu;
    public Canvas hud;

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
                hud.enabled = true;
            }
            else
            {
                menu.enabled = true;
                Time.timeScale = 0f;
                hud.enabled = false;
            }
        }
	}

    public void Resume()
    {
        Debug.Log("Resume");
        menu.enabled = false;
        hud.enabled = true;
        Time.timeScale = 1.0f;
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
