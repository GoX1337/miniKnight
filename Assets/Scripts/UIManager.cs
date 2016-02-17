using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas menu;
    public Canvas hud;
    public Camera camera;
    private GameObject main;
    private GameObject options;
    public float soundEffectsVolume = 1f;
    public float musicVolume = 1f;

	// Use this for initialization
	void Start () {
        menu.enabled = false;
        main = GameObject.Find("MainPanel");
        options = GameObject.Find("OptionsPanel");
        options.SetActive(false);
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
                camera.GetComponentInChildren<FPSDisplay>().showFps = true;
            }
            else
            {
                menu.enabled = true;
                Time.timeScale = 0f;
                hud.enabled = false;
                camera.GetComponentInChildren<FPSDisplay>().showFps = false;
            }
        }
	}

    public void Resume()
    {
        Debug.Log("Resume");
        menu.enabled = false;
        hud.enabled = true;
        Time.timeScale = 1.0f;
        camera.GetComponentInChildren<FPSDisplay>().showFps = true;
    }

    public void Options()
    {
        Debug.Log("Options");
        options.SetActive(true);
        main.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeSoundEffectsVolume(float value)
    {
        Debug.Log(value);
    }

    public void ChangeMusicVolume(float value)
    {
        Debug.Log(value);
    }

    public void ChangeFPSDisplay(bool fpsDisplay)
    {
        Debug.Log(fpsDisplay);
    }
}
