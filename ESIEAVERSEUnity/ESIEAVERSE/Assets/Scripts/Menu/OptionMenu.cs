using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : MonoBehaviour
{
    public TMP_Dropdown DResolution;
    public AudioSource audiosource;
    public Slider slider;

    public void SetResolution()
    {
        switch(DResolution.value)
        {
            case 0:
                //Screen.SetResolution(640, 360, false);
                break;
            case 1:
                //Screen.SetResolution(1080, 720, false);
                break;
            case 2:
                //Screen.SetResolution(1920, 1080, false);
                break;
        }
    }

    public void SetVolume()
    {
        audiosource.volume = slider.value;

    }

    public void SetFullScren()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
