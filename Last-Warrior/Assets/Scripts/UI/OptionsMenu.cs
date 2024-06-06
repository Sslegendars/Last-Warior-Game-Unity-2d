using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioManager audioManager;
   
    private void Start()
    {
        audioManager = AudioManager.instance;
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        //volumeSlider.value = audioManager.GetVolume();
    }

    public void OnVolumeChanged()
    {
       AudioListener.volume = volumeSlider.value;
    }

    /* public void SetVolume()
     {
         float volume = _slider.value;
         audioManager.SetVolume(volume);
     }
     */
}
