using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Settings
{
    public class SettingsGameController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private TMP_Dropdown qualityDropdown;

        private Resolution[] resolutions;

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropdown.value);
            PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
            PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        }

        private void Start()
        {
            AddResolutionOptions();
        }

        private void AddResolutionOptions()
        {
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            resolutions = Screen.resolutions;
            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = string.Format("{0}x{1} {2}Hz", resolutions[i].width, resolutions[i].height, resolutions[i].refreshRate);
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                    currentResolutionIndex = i;
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.RefreshShownValue();

            LoadSettings(currentResolutionIndex);
        }

        private void LoadSettings(int currentResolutionIndex)
        {
            if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            {
                qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
            }
            else
            {
                qualityDropdown.value = 3;
            }

            if (PlayerPrefs.HasKey("ResolutionPreference"))
            {
                resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
            }
            else 
            { 
                resolutionDropdown.value = 0; 
            }

            if (PlayerPrefs.HasKey("FullScreenPreference"))
            {
                Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
            }
            else
            {
                Screen.fullScreen = true;
            }
        }
    }
}
