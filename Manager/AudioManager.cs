using UnityEngine;
using System.Collections.Generic;

public class AudioManager
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AudioManager();
            }
            return _instance;
        }
    }

    private string savePath = "AudioInfo";
    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();

    private AudioSource audioSource;

    private AudioManager()
    {
        // audioDict.Clear();

        TextAsset audioInfo = Resources.Load<TextAsset>(savePath);
        string[] lines = audioInfo.text.Split('\n');
        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] pro = line.Split(',');
                string key = pro[0];
                AudioClip value = Resources.Load<AudioClip>(pro[1]);
                audioDict.Add(key, value);
            }
        }
    }

    public void Init()
    {
        // NONE
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void Play(string audioName)
    {
        AudioClip audioClip;
        audioDict.TryGetValue(audioName, out audioClip);
        if (audioClip != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning(audioName + "  Non-existent");
        }
    }

    public void SetMute(bool b)
    {
        audioSource.mute = b;
    }
}
