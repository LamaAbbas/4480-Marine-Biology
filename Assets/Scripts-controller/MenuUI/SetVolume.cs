using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour
{
    public void Start(){
        Slider sliderVal = GetComponent<Slider>();
        sliderVal.value = AudioListener.volume;
    }
    public void OnVolumeChange(){
        AudioListener.volume = GetComponent<Slider>().value;
    }
}
