using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public static int campus = 0;
    [SerializeField] Menu[] menus;
    [SerializeField] AudioClip[] clips;
    [SerializeField] Toggle I;
    [SerializeField] Toggle I2;

    void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
        if (menu.menuName != "title")
        {
            SoundManager.Instance.PlaySound(clips[1]);
        }
        SoundManager.Instance.PlaySound(clips[0]);

    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public void PlaySound()
    {
        int i = Random.Range(0, 4);
        SoundManager.Instance.PlaySound(clips[i]);
    }
    
    public void Ivry()
    {
        campus = 0;
        I.isOn = !I.isOn;
        I2.isOn = !I2.isOn;
    }

    public void Ivry2()
    {
        campus = 1;
        I2.isOn = !I2.isOn;
        I.isOn = !I.isOn;
    }

}
