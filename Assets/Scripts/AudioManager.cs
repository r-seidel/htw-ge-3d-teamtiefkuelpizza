using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundFiles[] sounds;

    void Awake()
    {
        foreach(SoundFiles s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
    }

    public void Play (string name)
    {
        SoundFiles s = Array.Find(sounds, sound => sound.name == name);
        //https://www.youtube.com/watch?v=6OT43pvUyfY&t=207s
        s.source.Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



/*
 Debug.Log("Sound Wave");

// Play Wave Sounds
if (WaveCount == 1){
    FindObjectOfType<AudioManager>().Play("EnemyWave01");
    FindObjectOfType<AudioManager>().Play("EnemyHorn01");
} 
if (WaveCount == 2){
    FindObjectOfType<AudioManager>().Play("EnemyWave02");
    FindObjectOfType<AudioManager>().Play("EnemyHorn02");
} 
if (WaveCount == 3){
    FindObjectOfType<AudioManager>().Play("EnemyWave03");
    FindObjectOfType<AudioManager>().Play("EnemyHorn03");
} 
if (WaveCount == 4){
    FindObjectOfType<AudioManager>().Play("EnemyWave04");
    FindObjectOfType<AudioManager>().Play("EnemyHorn04");
} 

// Play Ambient Sound
    FindObjectOfType<AudioManager>().Play("DesertWind");

// Save Enemy Sound
    FindObjectOfType<AudioManager>().Play("EnemySave01");

// Play TowerAvailable Sound
    FindObjectOfType<AudioManager>().Play("TowerAvailable");

// Play TowerAvailable Sound
    FindObjectOfType<AudioManager>().Play("TowerShot");

// Play TowerBuild Sound
    FindObjectOfType<AudioManager>().Play("TowerBuild");

// Play GameOver Sound
    FindObjectOfType<AudioManager>().Play("GameOver");

// Play GameStart Sound
    FindObjectOfType<AudioManager>().Play("GameStart");

    // Player shot Sound
    FindObjectOfType<AudioManager>().Play("PlayerShot");


*/