using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void PlayOneSound(AudioClip clip)
    {
        MusicManager.Instance.PlayOneSound(clip);
    }
}
