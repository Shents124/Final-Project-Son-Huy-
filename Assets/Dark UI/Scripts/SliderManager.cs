using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Dark
{
    public class SliderManager : MonoBehaviour
    {
        [Header("SAVING")]
        public bool enableSaving = false;
        public string sliderTag = "Tag Text";
        public float defaultValue = 1;
        
        private Slider mainSlider;
        float saveValue;

        void OnEnable()
        {
            mainSlider = this.GetComponent<Slider>();
            
            if (enableSaving == true)
            {
                if (PlayerPrefs.HasKey(sliderTag + "DarkSliderValue") == false)
                    saveValue = defaultValue;
                else
                    saveValue = PlayerPrefs.GetFloat(sliderTag + "DarkSliderValue");

                mainSlider.value = saveValue;

                mainSlider.onValueChanged.AddListener(delegate
                {
                    saveValue = mainSlider.value;
                    PlayerPrefs.SetFloat(sliderTag + "DarkSliderValue", saveValue);
                });
            }
        }
    }
}