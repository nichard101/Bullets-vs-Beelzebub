using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume2 : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    public void Start(){
        volumeSlider.value = GameMaster.volume;
    }

    public void ChangeVolume(){
        AudioListener.volume = volumeSlider.value;
        GameMaster.volume = volumeSlider.value;
    }
}
