using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private GameObject mainMenuButtons;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicVolumeSlider.value = savedVolume;
        if (musicSource != null)
        {
            musicSource.volume = savedVolume;
        }

        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        if (mainMenuButtons != null)
        {
            mainMenuButtons.SetActive(false);
        }
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        if (mainMenuButtons != null)
        {
            mainMenuButtons.SetActive(true);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
