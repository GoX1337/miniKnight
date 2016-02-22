using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas menu;
    public Canvas hud;
    public Camera camera;

    private GameObject main;

    private GameObject options;
    private bool inOptionsMenu = false;
    
    private float soundEffectsVolume = 1f;
    private bool soundVolChanged = false;
    private float musicVolume = 1f;
    private bool musicVolChanged = false;

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
                if (inOptionsMenu)
                {
                    options.SetActive(false);
                    main.SetActive(true);
                    inOptionsMenu = false;
                }
                else
                {
                    Resume();
                }
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
        AudioListener.pause = false;
        camera.GetComponentInChildren<FPSDisplay>().showFps = fpsDisplay;
        ApplyVolumeChanges();
    }

    public void Options()
    {
        options.SetActive(true);
        main.SetActive(false);
        inOptionsMenu = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeSoundEffectsVolume(float value)
    {
        this.soundEffectsVolume = value;
        this.soundVolChanged = true;
    }

    public void ChangeMusicVolume(float value)
    {

        this.musicVolume = value / 100;
        this.musicVolChanged = true;
    }

    public void ChangeFPSDisplay(bool fps)
    {
        this.fpsDisplay = fps;
    }

    public void ApplyOptionsAndBack()
    {
        options.SetActive(false);
        main.SetActive(true);
        inOptionsMenu = false;
    }

    private void ApplyVolumeChanges(){
        if (this.soundVolChanged)
        {
            foreach (GameObject soundSourceObj in GameObject.FindGameObjectsWithTag("Player"))
            {
                soundSourceObj.GetComponent<AudioSource>().volume = this.soundEffectsVolume;
            }
            foreach (GameObject soundSourceObj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                soundSourceObj.GetComponent<AudioSource>().volume = this.soundEffectsVolume;
            }
        }

        if (this.musicVolChanged)
        {
            GameObject musicSrc = GameObject.FindGameObjectWithTag("MusicSource");
            if(musicSrc != null){
                musicSrc.GetComponent<AudioSource>().volume = this.musicVolume;
            }
        }
    }
}
