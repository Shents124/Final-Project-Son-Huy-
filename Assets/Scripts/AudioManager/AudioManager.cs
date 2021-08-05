using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoSingleton<AudioManager>
{
    private const string AudioMixerMusic = "Music";
    private const string AudioMixerSFXGame = "SFXGame";
    
    public AudioMixer audioMixer;
    public GameObject houseMusic;
    public GameObject sfxWinGame;
    public GameObject sfxLoseGame;

    private float multiplier = 30f;

    public void PlayHouseMusic()
    {
        audioMixer.SetFloat(AudioMixerSFXGame,Mathf.Log10(PlayerPrefs.GetFloat("SFXDarkSliderValue")) * multiplier);
        audioMixer.SetFloat(AudioMixerMusic,Mathf.Log10(PlayerPrefs.GetFloat(AudioMixerMusic + "DarkSliderValue")) * multiplier);
        
        AudioSource audioSource = houseMusic.GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.loop = true;
    }

    private void StopPlayMusic()
    {
        audioMixer.SetFloat(AudioMixerSFXGame, -80);
        audioMixer.SetFloat(AudioMixerMusic, -80);
    }

    public void PlaySfxWinGame()
    {
        sfxWinGame.GetComponent<AudioSource>().Play();
        StopPlayMusic();
    }
    
    public void PlaySfxLoseGame()
    {
        sfxLoseGame.GetComponent<AudioSource>().Play();
        StopPlayMusic();
    }
}
