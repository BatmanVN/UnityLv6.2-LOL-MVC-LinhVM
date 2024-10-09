using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> audioSources;

    public void SlashSound() => audioSources[0].Play();
    public void KickSound() => audioSources[1].Play();
    public void SwordSound() => audioSources[2].Play();
    public void PowerUpSound() => audioSources[3].Play();
}
