using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;   
    private void Start()
    {        
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });       
    }
    public void OnVolumeChanged()
    {
       AudioListener.volume = volumeSlider.value;
    }
    
}
