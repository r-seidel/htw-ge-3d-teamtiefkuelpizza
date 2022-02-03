using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    public SoundFiles wind;
    public SoundFiles[] music;

    private bool playingMusic;
    private AudioSource audioSource;
    private SoundFiles lastTrack;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator IntoWind()
    {
        if (playingMusic)
        {
            Debug.Log("Into Wind");
            playingMusic = false;
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / 3f;

                yield return null;
            }

            audioSource.loop = true;
            audioSource.clip = wind.clip;
            audioSource.Play();

            while (audioSource.volume < wind.volume)
            {
                audioSource.volume += Time.deltaTime / 1f;

                yield return null;
            }
        }
    }

    public IEnumerator IntoMusic()
    {
        if (!playingMusic)
        {
            Debug.Log("Into Music");
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / 1f;

                yield return null;
            }

            audioSource.Stop();
            audioSource.loop = false;
            playingMusic = true;

            PlayRandomTrack();
        }
    }

    private void PlayRandomTrack()
    {
        if (lastTrack == null)
        {
            SoundFiles next = GetRandomTrack();
            audioSource.clip = next.clip;
            audioSource.volume = next.volume;
            audioSource.Play();
            lastTrack = next;
        }
        else
        {
            SoundFiles next = GetRandomTrack();
            while (lastTrack.clip == next.clip)
            {
                next = GetRandomTrack();
            }
            lastTrack = next;
            audioSource.clip = next.clip;
            audioSource.volume = next.volume;
            audioSource.Play();
        }
    }

    private SoundFiles GetRandomTrack()
    {
        int random = Random.Range(0, music.Length);
        return music[random];
    }
}
