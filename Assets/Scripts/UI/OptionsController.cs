using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Sprite noVolume;
    [SerializeField] Sprite Volume;

    [SerializeField] Slider music;
    [SerializeField] Slider sfx;

    [SerializeField] Button VolumeButton;

    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;

    private GlobalController globalController;

    private void Start()
    {
        globalController = GameObject.FindGameObjectWithTag("Singleton").GetComponent<GlobalController>();
        SetVolumeMusic(globalController.musicVolume);
        SetVolumeSFX(globalController.sfxVolume);
        music.value = globalController.musicVolume;
        sfx.value = globalController.sfxVolume;
    }

    private bool isVolumeOn = true;

    public void ClickVolume()
    {
        isVolumeOn = !isVolumeOn;

        if(isVolumeOn == true)
        {
            VolumeButton.image.sprite = Volume;
            music.value = -40;
            sfx.value = -40;
        }
        else
        {
            VolumeButton.image.sprite = noVolume;
            music.value = -80;
            sfx.value = -80;
        }
    }

    public void SetVolumeMusic(float volume)
    {
        MusicMixer.SetFloat("MusicVolume", volume);
        globalController.musicVolume = volume;
        CheckVolumeValue();
    }

    public void SetVolumeSFX(float volume)
    {
        SFXMixer.SetFloat("SFXVolume", volume);
        globalController.sfxVolume = volume;
        CheckVolumeValue();
    }

    private void CheckVolumeValue()
    {
        float sfxVol = 0;
        float musicVol = 0;
        SFXMixer.GetFloat(("SFXVolume"), out sfxVol);
        MusicMixer.GetFloat(("MusicVolume"), out musicVol);

        if (musicVol == -80 && sfxVol == -80)
        {
            isVolumeOn = false;
            VolumeButton.image.sprite = noVolume;
        }
        else
        {
            isVolumeOn = true;
            VolumeButton.image.sprite = Volume;
        }
    }
}
