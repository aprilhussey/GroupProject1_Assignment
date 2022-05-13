using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI = null;

    private void Start()
    {
        LoadValues();
    }

    private void Update()
    {
        SaveVolume();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = (volume * 100).ToString("0") + "%";
    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("GameVolume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
