using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq; 


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;

    public GameObject minimap;
    public bool minimapHere = true;

    /* liste des resolutions dispos */
    Resolution[] resolutions;

    public Slider musicSlider;
    public Slider soundSlider;

    public void Start()

    {
        // récupération des pistes audios
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height}).Distinct().ToArray();
        resolutionDropDown.ClearOptions(); 

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            /* C'est la résolution de l'utilisateur ? */
            /* Si oui, on l'applique automatiquement */
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        Screen.fullScreen = true;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        Debug.Log(volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }

    public void SetFullScreen(bool isFullScren)
    {
        Screen.fullScreen = isFullScren;
    }

    public void SetMinimap()
    {
        if (minimapHere)
        {
            minimap.SetActive(false);
            minimapHere = false;
        }
        else
        {
            minimap.SetActive(true);
            minimapHere = true;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    
}