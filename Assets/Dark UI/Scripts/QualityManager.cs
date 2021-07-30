using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Michsky.UI.Dark
{
    public class QualityManager : MonoBehaviour
    {
        private const string AnisotropicFilteringKey = "AnisotropicFiltering";
        private const string AntiAliasingKey = "AntiAliasing";
        private const string ShadowResolutionKey = "ShadowResolution";
        private const string TextureKey = "Texture";
        private const string ReflectionKey = "Reflection";
        
        [Header("AUDIO")]
        public AudioMixer mixer;
        public SliderManager masterSlider;
        public SliderManager musicSlider;
        public SliderManager sfxSlider;

        public CustomDropdown anisotropicFiltering;
        public CustomDropdown antiAliasing;
        public CustomDropdown shadowResolution;
        public CustomDropdown textureDropdown;
        public CustomDropdown reflectionDropdown;

        private float multiplier = 30f;
        
        void OnEnable()
        {
            LoadSetting();
        }

        private void Start()
        {
            mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat(masterSlider.sliderTag + "DarkSliderValue")) * multiplier);
            mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat(musicSlider.sliderTag + "DarkSliderValue")) * multiplier);
            mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat(sfxSlider.sliderTag + "DarkSliderValue")) * multiplier);
        }

        public void AnisotropicFilteringEnable()
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
            PlayerPrefs.SetInt(AnisotropicFilteringKey, anisotropicFiltering.selectedItemIndex);
        }

        public void AnisotropicFilteringDisable()
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            PlayerPrefs.SetInt(AnisotropicFilteringKey, anisotropicFiltering.selectedItemIndex);
        }

        public void AntiAliasingSet(int index)
        {
            // 0, 2, 4, 8 - Zero means off
            QualitySettings.antiAliasing = index;
            PlayerPrefs.SetInt(AntiAliasingKey, antiAliasing.selectedItemIndex);
        }
        
        public void ShadowResolutionSet(int index)
        {
            if (index == 3)
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
            else if (index == 2)
                QualitySettings.shadowResolution = ShadowResolution.High;
            else if (index == 1)
                QualitySettings.shadowResolution = ShadowResolution.Medium;
            else if (index == 0)
                QualitySettings.shadowResolution = ShadowResolution.Low;
            
            PlayerPrefs.SetInt(ShadowResolutionKey, shadowResolution.selectedItemIndex);
        }

        public void TextureSet(int index)
        {
            // 0 = Full, 4 = Eight Resolution
            QualitySettings.masterTextureLimit = index;
            PlayerPrefs.SetInt(TextureKey, textureDropdown.selectedItemIndex);
        }
        
        public void ReflectionSet(int index)
        {
            if (index == 0)
                QualitySettings.realtimeReflectionProbes = false;
            else if (index == 1)
                QualitySettings.realtimeReflectionProbes = true;

            PlayerPrefs.SetInt(ReflectionKey, reflectionDropdown.selectedItemIndex);
        }

        public void VolumeSetMaster(float volume)
        {
            mixer.SetFloat("Master", Mathf.Log10(volume) * multiplier);
        }

        public void VolumeSetMusic(float volume)
        {
            mixer.SetFloat("Music", Mathf.Log10(volume) * multiplier);
        }

        public void VolumeSetSFX(float volume)
        {
            mixer.SetFloat("SFX", Mathf.Log10(volume) * multiplier);
        }

        private void LoadSetting()
        {
            anisotropicFiltering.selectedItemIndex = 
                PlayerPrefs.HasKey(AnisotropicFilteringKey) ? PlayerPrefs.GetInt(AnisotropicFilteringKey) : 0;

            antiAliasing.selectedItemIndex = PlayerPrefs.HasKey(AntiAliasingKey) ? PlayerPrefs.GetInt(AntiAliasingKey) : 0;

            shadowResolution.selectedItemIndex =
                PlayerPrefs.HasKey(ShadowResolutionKey) ? PlayerPrefs.GetInt(ShadowResolutionKey) : 0;

            textureDropdown.selectedItemIndex = PlayerPrefs.HasKey(TextureKey) ? PlayerPrefs.GetInt(TextureKey) : 0;

            reflectionDropdown.selectedItemIndex =
                PlayerPrefs.HasKey(ReflectionKey) ? PlayerPrefs.GetInt(ReflectionKey) : 0;
        }
    }
}