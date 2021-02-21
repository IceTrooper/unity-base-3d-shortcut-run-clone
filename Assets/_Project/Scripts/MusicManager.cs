using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<MusicManager>();
            }
            return instance;
        }
    }

    [SerializeField] private AudioSource soundsAudioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void PlayOneSound(AudioClip clip)
    {
        soundsAudioSource.PlayOneShot(clip);
    }
}
