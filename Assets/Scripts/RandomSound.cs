using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RandomSound : MonoBehaviour {

    public string folderName;
    private AudioSource audioSource;
    private List<AudioClip> audioClipList = new List<AudioClip>();
    private float maxLength;

	// Use this for initialization
	void Start () {
        this.audioSource = GetComponent<AudioSource>();
        if (this.audioSource == null)
            return;

        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Sound/" + folderName);
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info) 
        {
            if (!f.Name.EndsWith(".meta"))
            {
                AudioClip clip = Resources.Load("Sound/" + folderName + "/" + f.Name.Substring(0, f.Name.LastIndexOf("."))) as AudioClip;
                if (clip != null)
                {
                    audioClipList.Add(clip);
                    if (maxLength < clip.length)
                    {
                        maxLength = clip.length;
                    }
                }
            }
        }
        Debug.Log("RandomSound>" + this.folderName + ": " + audioClipList.Count + " sounds loaded");
	}

    public AudioClip GetRandomSound()
    {
        return this.audioClipList[Random.Range(0, audioClipList.Count)];
    }

    public float GetMaxLength()
    {
        return this.maxLength;
    }
}
