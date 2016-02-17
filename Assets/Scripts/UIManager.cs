using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas menu;
    public Canvas hud;
    public Camera camera;
    private GameObject main;
    private GameObject options;
    
    private float soundEffectsVolume = 1f;
    private float musicVolume = 1f;
    private bool fpsDisplay = true;
    public UnityEngine.UI.Toggle fpsToogle;

	// Use this for initialization
	void Start () {
        menu.enabled = false;
        main = GameObject.Find("MainPanel");
        options = GameObject.Find("OptionsPanel");
        options.SetActive(false);
        AudioListener.pause = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.enabled)
            {
                Resume();
            }
            else
            {
                Menu();
            }
        }
	}

    public void Menu()
    {
        menu.enabled = true;
        Time.timeScale = 0f;
        hud.enabled = false;
        camera.GetComponentInChildren<FPSDisplay>().showFps = false;
        fpsToogle.isOn = fpsDisplay;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        menu.enabled = false;
        hud.enabled = true;
        Time.timeScale = 1.0f;
        camera.GetComponentInChildren<FPSDisplay>().showFps = fpsDisplay;
        AudioListener.pause = false;
    }

    public void Options()
    {
        options.SetActive(true);
        main.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeSoundEffectsVolume(float value)
    {
        this.soundEffectsVolume = value;
    }

    public void ChangeMusicVolume(float value)
    {
        this.musicVolume = value;
    }

    public void ChangeFPSDisplay(bool fps)
    {
        this.fpsDisplay = fps;
    }

    public void ApplyOptionsAndBack()
    {
        options.SetActive(false);
        main.SetActive(true);
    }
}
