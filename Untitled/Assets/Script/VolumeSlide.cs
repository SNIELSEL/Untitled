using Coffee.UIExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeSlide : MonoBehaviour
{
    public Slider volumeSlider;

    public UIParticle sliderParticle;
    public ParticleSystem[] particlesettings;

    private bool playingParticles;

    public SaveAndLoad saveAndLoad;

    void Start()
    {
        LoadVolume();

        if (saveAndLoad.volume == 0)
        {
            saveAndLoad.volume = 1;
            SaveVolume();
            LoadVolume();
        }
    }

    public void VolumeChanger()
    {
        saveAndLoad.volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    public void LoadVolume()
    {
        saveAndLoad.LoadData();
        volumeSlider.value = saveAndLoad.volume;
    }

    public void SaveVolume()
    {
        saveAndLoad.SaveData();
    }

    public void SpawnParticle()
    {
        if(!playingParticles)
        {
            playingParticles = true;
            sliderParticle.Play();
        }
    }

    public void EndParticle()
    {
        playingParticles = false;
        particlesettings[0].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        particlesettings[1].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        particlesettings[2].Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
